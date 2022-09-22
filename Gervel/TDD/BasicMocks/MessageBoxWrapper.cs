using Core.Attributes;
using System.Windows.Forms;

namespace BasicMocks {

	[Service(Contract = typeof(IMessageBox))]
	public class MessageBoxWrapper : IMessageBox {
        public DialogResult Show(string text, string caption) {
            return MessageBox.Show(text, caption);
		}
    }
}
