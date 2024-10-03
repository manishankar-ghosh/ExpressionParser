using ExpressionParser;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExpressionParserSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnMatch_Click(object sender, EventArgs e)
        {
            //var data = new List<TokenValueWithDataType>
            //{
            //    new() { Token= "Salary", Value = "4000", DataType= 'i'},
            //    new() { Token= "Bonus", Value = "900", DataType= 'i'},
            //    new() { Token= "Address", Value = "Delhi Central", DataType= 's'},
            //    new() { Token= "Dgn", Value = "Manager", DataType= 's'},
            //    new() { Token= "DOJ", Value = "01 Jan 2000", DataType= 't'}
            //};

            var data = new List<TokenValueWithDataType>
            {
                new() { Token= Enum.GetName(CriteriaFields.Salary), Value = "4000", DataType= DataType.Integer},
                new() { Token= Enum.GetName(CriteriaFields.Bonus), Value = "900", DataType= DataType.Integer},
                new() { Token= Enum.GetName(CriteriaFields.Address), Value = "Delhi Central", DataType= DataType.String},
                new() { Token= Enum.GetName(CriteriaFields.Dgn), Value = "Manager", DataType= DataType.String},
                new() { Token= Enum.GetName(CriteriaFields.DOJ), Value = "01 Jan 2000", DataType= DataType.DateTime}
            };

            //string criteria = "(Salary >= 5000 -a Dgn = Manager) -o (Bonus >= 1000 -a Address = Delhi Central) -o DOJ <= 01 Jan 2000";

            bool result = MatchCriteria.IsMatching(data, txtCriteria.Text);
            MessageBox.Show(result.ToString(), "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMatch2_Click(object sender, EventArgs e)
        {
            //var result2 = new DataTable().Compute("'5\' < '7'", null);

            var data = new List<TokenValueWithDataType>
            {
                new() { Token= "Salary", Value = "4000", DataType= 'i'},
                new() { Token= "Bonus", Value = "900", DataType= 'i'},
                new() { Token= "Address", Value = "Delhi Central", DataType= 's'},
                new() { Token= "Dgn", Value = "Manager", DataType= 's'},
                new() { Token= "DOJ", Value = "01 Jan 2000", DataType= 't'}
            };

            string criteria = "(Salary >= 5000 AND Dgn = 'Manager') OR (Bonus >= 1000 AND Address = 'Delhi Central') OR DOJ <= #01 Jan 2000#";

            bool result = MatchCriteria.IsMatching2(data, txtCriteria.Text);
            MessageBox.Show(result.ToString(), "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    enum CriteriaFields
    {
        Salary,
        Bonus,
        Address,
        Dgn,
        DOJ
    }
}
