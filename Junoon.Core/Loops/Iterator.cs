namespace Junoon.Core
{
    public class Iterator
    {
        public Iterator(IteratorSign sign, uint stepSize)
        {
            Sign = sign;
            StepSize = stepSize;
        }

        public IteratorSign Sign { get; }
        public IteratorVariableType VariableType { get; } = IteratorVariableType.Int;
        public uint StepSize { get; }

        public enum IteratorSign
        {
            Positive,
            Negative
        }

        public enum IteratorVariableType
        {
            Int,
            Long,
            Short,
        }
    }
}