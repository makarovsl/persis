using System;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace Client.Controls
{
    public partial class Paginator : UserControl
    {
        public event EventHandler PageChange;

        private int _rowCount;
        public Func<int> GetRowCount;
        public int PageSize { get; private set; }
        public int CurrenPage { get; private set; }

        private int _pageCount;
        public Paginator()
        {
            InitializeComponent();
        }

        private void Paginator_Load(object sender, EventArgs e)
        {
            pageUpDown.ValueChanged += PaginationAttributeChange;
            pageSizeUpDown.ValueChanged += PaginationAttributeChange;
            if (GetRowCount != null)
                _rowCount = Program.PerformCall(GetRowCount);

            RecalcData();
        }

        private void RecalcData()
        {
            PageSize = Convert.ToInt32(pageSizeUpDown.Value);
            CurrenPage = Convert.ToInt32(pageUpDown.Value);

            if (_rowCount == 0 || _rowCount < PageSize)
            {
                _pageCount = 1;
            }
            else
            {
                if (_rowCount % PageSize == 0)
                {
                    _pageCount = _rowCount / PageSize;
                }
                else
                {
                    _pageCount = _rowCount / PageSize + 1;
                }
            }
            pageUpDown.Maximum = _pageCount;
            labelPageCount.Text = _pageCount.ToString();
            OnPageChange();
        }

        private void PaginationAttributeChange(object sender, EventArgs e)
        {
            RecalcData();
        }

        protected virtual void OnPageChange()
        {
            PageChange?.Invoke(this, EventArgs.Empty);
        }
    }
}
