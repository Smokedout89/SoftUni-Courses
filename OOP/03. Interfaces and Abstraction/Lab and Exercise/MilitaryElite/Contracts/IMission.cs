using MilitaryElite.Enums;

namespace MilitaryElite.Contracts
{
    public interface IMission
    {
        public string CodeName { get; set; }

        public  State State { get; set; }
    }
}