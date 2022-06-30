namespace HttpStatusCode.Models.DTOs.Entities.Abstract
{

    public enum Status
    {
        Active,
        Modified,
        Passive
    }

    public abstract class BaseEntity
    {
        public int Id { get; set; }
        private DateTime _created = DateTime.Now;
        public DateTime CreateDate { get => _created; set => _created = value; }
        public DateTime? UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }

        private Status _status = Status.Active;

        public Status Status
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}
