using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public interface FieldBinding
	{
		Control BoundControl { get; }
		void LoadField(string data);
		string RetreiveField();
	}
}
