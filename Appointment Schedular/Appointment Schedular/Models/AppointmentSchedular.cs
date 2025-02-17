using System;
using System.Collections.Generic;

namespace Appointment_Schedular.Models;

public partial class AppointmentSchedular
{
    public int AppointmentId { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateOnly Date { get; set; }

    public TimeOnly TimeSlot { get; set; }

    public string RemarkOfAppointment { get; set; } = null!;

    public int? NoOfHours { get; set; }

    public decimal FeesCharged { get; set; }
}
