using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KabuTradeTool2
{
    class ViewModel:INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        private string _title;
        private ObservableCollection<StockEntity> _stockList;
        private DownloadCommand _downloadCommand;
        private StocksRepository _repository;

        public ViewModel()
        {
            _repository = new StocksRepository();
            _downloadCommand = new DownloadCommand(Execute);
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged("Title"); }
        }

        public ObservableCollection<StockEntity> StockEntityList
        {
            get { return _stockList; }
            set { _stockList = value; OnPropertyChanged("StockEntityList"); }
        }

        public DownloadCommand DownloadCommand
        {
            get
            {
                return _downloadCommand;
            }
        }

        private void Execute()
        {
            string[] rows = _repository.GetCSVData();
            Title = rows.First();

            var list = new List<StockEntity>();

            Func<string, StockEntity> converter = row =>
            {
                var fields = row.Split(new char[] { ',' });

                return new StockEntity()
                {
                    Code = fields[0],
                    Name = fields[1],
                    Market = fields[2],
                    Category = fields[3],
                    Opening = fields[4],
                    High = fields[5],
                    Low = fields[6],
                    Closing = fields[7],
                    Volume = fields[8],
                    Turnover = fields[9],
                };
            };

            rows.Skip(2).ToList().ForEach(row => list.Add(converter(row)));

            StockEntityList = new ObservableCollection<StockEntity>(list);
        }
    }
}
