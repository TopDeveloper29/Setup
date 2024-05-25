using MaterialSkin.Controls;

namespace Setup.Forms
{
    public partial class AddScriptForm : MaterialForm
    {
        public AddScriptForm(string Name = null, string Script = null)
        {
            InitializeComponent();
            Theme.Init(this);
            if (Name != null ) { DisplayName.Text = Name; AddBt.Text = "Save"; }
            if (Script != null ) { Scripts.Text = Script; AddBt.Text = "Save"; }
        }
    }
}
