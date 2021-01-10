using Review.Infrastructure.Data;
using System;

namespace Review.Infrastructure.Domain
{
    public class ReviewDomain : BaseDomain
    {
        /// <summary>
        /// Id записи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Название организации
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// Адрес организации
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Что понравилось?
        /// </summary>
        public string LikeMessage { get; set; }

        /// <summary>
        /// Что не понравилось?
        /// </summary>
        public string DislikeMessage { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Оценка
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Признак удаленного
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
