namespace QHAQFWS.Model
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	public partial class Forecast_Pollutant_Range
	{
		private int _id;
		public virtual int Id
		{
			get
			{
				return this._id;
			}
			set
			{
				this._id = value;
			}
		}

		private string _pollutant;
		public virtual string Pollutant
		{
			get
			{
				return this._pollutant;
			}
			set
			{
				this._pollutant = value;
			}
		}

		private decimal? _upperlimit;
		public virtual decimal? Upperlimit
		{
			get
			{
				return this._upperlimit;
			}
			set
			{
				this._upperlimit = value;
			}
		}

		private decimal? _lowerlimit;
		public virtual decimal? Lowerlimit
		{
			get
			{
				return this._lowerlimit;
			}
			set
			{
				this._lowerlimit = value;
			}
		}

		private bool? _status;
		public virtual bool? Status
		{
			get
			{
				return this._status;
			}
			set
			{
				this._status = value;
			}
		}

	}
}
