namespace Barco.Librairie.Domain.ValueObjects
{
    public record Currency
    {
        public string Code { get; }

        public Currency(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Currency code cannot be empty");

            Code = code;
        }
    }
}