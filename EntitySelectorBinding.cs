using System.Windows.Forms;

namespace SDA_DonationTracker
{
	class EntitySelectorBinding : FieldBinding
	{
		~EntitySelectorBinding()
		{
			this.Selector.Deinitialize();
		}

		public EntitySelector Selector { get; private set; }

		public Control BoundControl
		{
			get { return this.Selector; }
		}

		public EntitySelectorBinding(EntitySelector selector)
		{
			this.Selector = selector;
		}

		public void LoadField(string data)
		{
			this.Selector.SetSelectedId(data != null ? (int?)int.Parse(data) : null);
		}

		public string RetreiveField()
		{
			int? selectedId = this.Selector.GetSelectedId();

			if (selectedId != null)
				return selectedId.ToString();
			else
				return null;
		}
	}
}
