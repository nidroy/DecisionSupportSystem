using System.Data;

namespace DecisionSupportSystem
{
    public partial class RoadObject : Form
    {
        public RoadObject()
        {
            InitializeComponent();
            SelectRoadObject();
        }

        private void SelectRoadObject()
        {
            DataSet ds = DatabaseContext.ExecuteQuery("" +
                "SELECT " +
                "[id] as [�������������], " +
                "[name] as [��������], " +
                "[passport] as [�������], " +
                "[photo] as [����], " +
                "[status] as [���������], " +
                "[priority] as [���������] " +
                "FROM [RoadObject];");

            dataGridView.DataSource = ds.Tables[0].DefaultView;
        }
    }
}