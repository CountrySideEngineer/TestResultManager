using System;
using System.Collections.Generic;
using System.Text;

namespace DBConnector.DTO
{
    public class DTOBase
    {
        /// <summary>
        /// Record id, primary key.
        /// </summary>
        public int ID { get; set; } = 0;

        /// <summary>
        /// Date time the record created at.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Date time the record updated at last time.
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DTOBase() { }
    }
}
