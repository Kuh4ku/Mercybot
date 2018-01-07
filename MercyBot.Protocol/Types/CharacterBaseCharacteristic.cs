namespace MercyBot.Protocol.Types
{
    public class CharacterBaseCharacteristic
	{

		// Properties
		public int Base { get; set; }
		public int ObjectsAndMountBonus { get; set; }
		public int AlignGiftBonus { get; set; }
		public int ContextModif { get; set; }

        public int Total => Base + ObjectsAndMountBonus + AlignGiftBonus + ContextModif;


        // Constructors
        public CharacterBaseCharacteristic() { }

		public CharacterBaseCharacteristic(int @base = 0, int objectsAndMountBonus = 0, int alignGiftBonus = 0, int contextModif = 0)
		{
			Base = @base;
			ObjectsAndMountBonus = objectsAndMountBonus;
			AlignGiftBonus = alignGiftBonus;
			ContextModif = contextModif;
		}



	}
}
