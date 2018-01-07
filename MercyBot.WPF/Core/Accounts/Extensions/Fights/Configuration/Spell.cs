using MercyBot.Core.Accounts.Extensions.Fights.Configuration.Enums;
using System.IO;

namespace MercyBot.Core.Accounts.Extensions.Fights.Configuration
{
    public class Spell
    {

        // Properties
        public int SpellId { get; private set; }
        public string SpellName { get; private set; }
        public SpellTargets Target { get; private set; }
        public byte Turns { get; private set; }
        public byte LastTurn { get; set; }
        public byte Relaunchs { get; private set; }
        public byte RemainingRelaunchs { get; set; }
        public byte TargetHp { get; private set; }
        public byte CharacterHp { get; private set; }
        public SpellResistances Resistance { get; private set; }
        public byte ResistanceValue { get; private set; }
        public byte DistanceToClosestMonster { get; private set; }
        public bool HandToHand { get; private set; }
        public bool AOE { get; private set; }
        public bool CarefulAOE { get; private set; }
        public bool AvoidAllies { get; private set; }


        // Constructor
        public Spell(int spellId, string spellName, SpellTargets target, byte turns, byte relaunchs, byte targetHp, byte characterHp, SpellResistances resistance,
            byte resistanceValue, byte distanceToClosestMonster, bool handToHand, bool aoe, bool carefulAOE, bool avoidAllies)
        {
            SpellId = spellId;
            SpellName = spellName;
            Target = target;
            Turns = turns;
            LastTurn = 0;
            Relaunchs = relaunchs;
            RemainingRelaunchs = Relaunchs;
            TargetHp = targetHp;
            CharacterHp = characterHp;
            Resistance = resistance;
            ResistanceValue = resistanceValue;
            DistanceToClosestMonster = distanceToClosestMonster;
            HandToHand = handToHand;
            AOE = aoe;
            CarefulAOE = carefulAOE;
            AvoidAllies = avoidAllies;
        }


        public void Save(BinaryWriter bw)
        {
            bw.Write(SpellId);
            bw.Write(SpellName);
            bw.Write((byte)Target);
            bw.Write(Turns);
            bw.Write(Relaunchs);
            bw.Write(TargetHp);
            bw.Write(CharacterHp);
            bw.Write((byte)Resistance);
            bw.Write(ResistanceValue);
            bw.Write(DistanceToClosestMonster);
            bw.Write(HandToHand);
            bw.Write(AOE);
            bw.Write(CarefulAOE);
            bw.Write(AvoidAllies);
        }

        public static Spell Load(BinaryReader br)
        {
            return new Spell(br.ReadInt32(), br.ReadString(),  (SpellTargets)br.ReadByte(),
                             br.ReadByte(), br.ReadByte(), br.ReadByte(), br.ReadByte(),
                             (SpellResistances)br.ReadByte(), br.ReadByte(), br.ReadByte(),
                             br.ReadBoolean(), br.ReadBoolean(), br.ReadBoolean(), br.ReadBoolean());
        }

    }
}
