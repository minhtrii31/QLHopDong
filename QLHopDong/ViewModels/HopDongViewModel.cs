using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using Prism.Mvvm;
using QLHopDong.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace QLHopDong.ViewModels
{
    public class HopDongViewModel : BindableBase
    {
        private string _contractID;
        public string ContractID
        {
            get { return _contractID; }
            set { SetProperty(ref _contractID, value); }
        }

        private string _contractName;
        public string ContractName
        {
            get { return _contractName; }
            set { SetProperty(ref _contractName, value); }
        }

        private DateOnly _contractDate;
        public DateOnly ContractDate
        {
            get { return _contractDate; }
            set { SetProperty(ref _contractDate, value); }
        }

        private string _contractLocation;
        public string ContractLocation
        {
            get { return _contractLocation; }
            set { SetProperty(ref _contractLocation, value); }
        }

        private string _selectedPartyA;
        public string SelectedPartyA
        {
            get { return _selectedPartyA; }
            set { SetProperty(ref _selectedPartyA, value); }
        }

        private string _selectedPartyB;
        public string SelectedPartyB
        {
            get { return _selectedPartyB; }
            set { SetProperty(ref _selectedPartyB, value); }
        }

        private string _contractValue;
        public string ContractValue
        {
            get { return _contractValue; }
            set { SetProperty(ref _contractValue, value); }
        }

        private DateOnly _startDate;
        public DateOnly StartDate
        {
            get { return _startDate; }
            set { SetProperty(ref _startDate, value); }
        }

        private DateOnly _endDate;
        public DateOnly EndDate
        {
            get { return _endDate; }
            set { SetProperty(ref _endDate, value); }
        }

        private ObservableCollection<string> _terms;
        public ObservableCollection<string> Terms
        {
            get { return _terms; }
            set { SetProperty(ref _terms, value); }
        }

        private ObservableCollection<string> _partyAOptions;
        public ObservableCollection<string> PartyAOptions
        {
            get { return _partyAOptions; }
            set { SetProperty(ref _partyAOptions, value); }
        }

        private ObservableCollection<string> _partyBOptions;
        public ObservableCollection<string> PartyBOptions
        {
            get { return _partyBOptions; }
            set { SetProperty(ref _partyBOptions, value); }
        }

        public DelegateCommand AddTermCommand { get; private set; }

        private int _nextTermNumber;

        public DelegateCommand GenerateDocumentCommand { get; private set; }

        public HopDongViewModel()
        {
            Terms = new ObservableCollection<string>();
            PartyAOptions = new ObservableCollection<string>();
            PartyBOptions = new ObservableCollection<string>();
            AddTermCommand = new DelegateCommand(ExecuteAddTermCommand);
            _nextTermNumber = 1;
            ContractID = Guid.NewGuid().ToString();

            LoadPartyOptions();

            GenerateDocumentCommand = new DelegateCommand(ExecuteGenerateDocumentCommand);
        }

        private void ExecuteAddTermCommand()
        {
            Terms.Add($"Điều {_nextTermNumber++}:");
        }

        private void LoadPartyOptions()
        {
            using (var dbContext = new QlhopDongContext())
            {
                var partyAList = dbContext.PartyAs.Select(p => p.PartyAname).ToList();
                var partyBList = dbContext.PartyBs.Select(p => p.PartyBname).ToList();

                PartyAOptions.AddRange(partyAList);
                PartyBOptions.AddRange(partyBList);
            }
        }

        private void ExecuteGenerateDocumentCommand()
        {
            Contract newContract = new()
            {
                ContractId = ContractID,
                ContractName = ContractName,
                ContractType = "Hợp đồng",
                ContractStart = StartDate,
                ContractEnd = EndDate
            };

            using (var context = new QlhopDongContext())
            {
                context.Contracts.Add(newContract);
                context.SaveChanges();

                string newContractID = newContract.ContractId;

                var selectedPartyAID = context.PartyAs.Where(p => p.PartyAname == SelectedPartyA).Select(p => p.PartyAid).FirstOrDefault();
                var selectedPartyBID = context.PartyBs.Where(p => p.PartyBname == SelectedPartyB).Select(p => p.PartyBid).FirstOrDefault();

                ContractDetail contractDetail = new ContractDetail
                {
                    ContractDetailId = String.Concat("CTHD", ContractID),
                    ContractId = newContractID,
                    ContractDetailContent = ContractName,
                    ContractDetailValue = int.Parse(ContractValue),
                    ContractDetailStatus = "Đã ký",
                    ContractDetailResign = 0,
                    PartyAid = selectedPartyAID,
                    PartyBid = selectedPartyBID,
                };

                context.ContractDetails.Add(contractDetail);
                context.SaveChanges();
            }

            GenerateWordDocument();
        }

        private void GenerateWordDocument()
        {
            string templateFilePath = "./Assets/Templates/hopdong.docx";
            string documentsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string outputFilePath = Path.Combine(documentsFolderPath, "output_hopdong.docx");

            File.Copy(templateFilePath, outputFilePath, true);

            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(outputFilePath, true))
            {
                MainDocumentPart mainPart = wordDocument.MainDocumentPart;
                if (mainPart != null)
                {
                    FillInDocument(mainPart.Document.Body);
                }
            }
        }

        private string DateOnlyToString(DateOnly date)
        {
            return date.ToString("dd/MM/yyyy");
        }

        private void FillInDocument(Body body)
        {
            FillInTextContent(body, "_tenHD", ContractName);
            FillInTextContent(body, "_ngay", ContractDate.Day.ToString());
            FillInTextContent(body, "_thang", ContractDate.Month.ToString());
            FillInTextContent(body, "_nam", ContractDate.Year.ToString());
            FillInTextContent(body, "_diadiemKy", ContractLocation);
            FillInTextContent(body, "_ngayBD", DateOnlyToString(StartDate));
            FillInTextContent(body, "_ngayKT", DateOnlyToString(EndDate));
            FillInTextContent(body, "_giatri", ContractValue.ToString());

            using (var dbContext = new QlhopDongContext())
            {
                var selectedPartyAInfo = dbContext.PartyAs.FirstOrDefault(p => p.PartyAname == SelectedPartyA);
                if (selectedPartyAInfo != null)
                {
                    FillInTextContent(body, "_benA", selectedPartyAInfo.PartyAname);
                    FillInTextContent(body, "_diachiA", selectedPartyAInfo.PartyAaddress);
                    FillInTextContent(body, "_dienthoaiA", selectedPartyAInfo.PartyAcontact.ToString());
                    FillInTextContent(body, "_taikhoanA", selectedPartyAInfo.PartyAaccount.ToString());
                    FillInTextContent(body, "_mstA", selectedPartyAInfo.PartyAtax.ToString());
                    FillInTextContent(body, "_daidienA", selectedPartyAInfo.PartyArepresentive);
                    FillInTextContent(body, "_chucvuA", selectedPartyAInfo.PartyAposition);
                }

                var selectedPartyBInfo = dbContext.PartyBs.FirstOrDefault(p => p.PartyBname == SelectedPartyB);
                if (selectedPartyBInfo != null)
                {
                    FillInTextContent(body, "_benB", selectedPartyBInfo.PartyBname);
                    FillInTextContent(body, "_diachiB", selectedPartyBInfo.PartyBaddress);
                    FillInTextContent(body, "_dienthoaiB", selectedPartyBInfo.PartyBcontact.ToString());
                    FillInTextContent(body, "_taikhoanB", selectedPartyBInfo.PartyBaccount.ToString());
                    FillInTextContent(body, "_mstB", selectedPartyBInfo.PartyBtax.ToString());
                    FillInTextContent(body, "_daidienB", selectedPartyBInfo.PartyBrepresentive);
                    FillInTextContent(body, "_chucvuB", selectedPartyBInfo.PartyBposition);
                }
            }
        }

        private void FillInTextContent(Body body, string placeholder, string value)
        {
            foreach (var textElement in body.Descendants<Text>())
            {
                if (textElement.Text.Contains(placeholder))
                {
                    textElement.Text = textElement.Text.Replace(placeholder, value);
                }
            }
        }
    }
}
