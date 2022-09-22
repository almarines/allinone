using System.Windows.Forms;

namespace BasicMocks {
	public interface IMessageBox {
        DialogResult Show(string text, string caption);
    }
}
