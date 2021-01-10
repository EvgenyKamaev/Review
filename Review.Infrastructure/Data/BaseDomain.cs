namespace Review.Infrastructure.Data
{
    public abstract class BaseDomain
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as BaseDomain);
        }

        public virtual bool Equals(BaseDomain other)
        {
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
