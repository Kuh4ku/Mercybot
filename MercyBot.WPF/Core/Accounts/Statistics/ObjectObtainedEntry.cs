using GalaSoft.MvvmLight;

namespace MercyBot.Core.Accounts.Statistics
{
    public class ObjectObtainedEntry : ViewModelBase
    {

        // Fields
        private uint _quantity;
        private uint _percentage;


        // Properties
        public uint GID { get; private set; }
        public string Name { get; private set; }
        public uint Quantity
        {
            get => _quantity;
            set => Set(ref _quantity, value);
        }
        public uint Percentage
        {
            get => _percentage;
            set => Set(ref _percentage, value);
        }

        // Constructor
        public ObjectObtainedEntry(uint gid, string name, uint qty)
        {
            GID = gid;
            Name = name;
            Quantity = qty;
        }

    }
}
