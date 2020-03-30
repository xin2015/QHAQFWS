namespace QHAQFWS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

	public partial class Weather_H_SpiData
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

		private string _cityName;
		public virtual string CityName
		{
			get
			{
				return this._cityName;
			}
			set
			{
				this._cityName = value;
			}
		}

		private DateTime? _timePoint;
		public virtual DateTime? TimePoint
		{
			get
			{
				return this._timePoint;
			}
			set
			{
				this._timePoint = value;
			}
		}

		private DateTime? _createTime;
		public virtual DateTime? CreateTime
		{
			get
			{
				return this._createTime;
			}
			set
			{
				this._createTime = value;
			}
		}

		private decimal? _windDirection;
		public virtual decimal? WindDirection
		{
			get
			{
				return this._windDirection;
			}
			set
			{
				this._windDirection = value;
			}
		}

		private decimal? _windSpeed;
		public virtual decimal? WindSpeed
		{
			get
			{
				return this._windSpeed;
			}
			set
			{
				this._windSpeed = value;
			}
		}

		private decimal? _airPress;
		public virtual decimal? AirPress
		{
			get
			{
				return this._airPress;
			}
			set
			{
				this._airPress = value;
			}
		}

		private decimal? _airTemperature;
		public virtual decimal? AirTemperature
		{
			get
			{
				return this._airTemperature;
			}
			set
			{
				this._airTemperature = value;
			}
		}

		private int? _rainLevel;
		public virtual int? RainLevel
		{
			get
			{
				return this._rainLevel;
			}
			set
			{
				this._rainLevel = value;
			}
		}

		private decimal? _relHumidity;
		public virtual decimal? RelHumidity
		{
			get
			{
				return this._relHumidity;
			}
			set
			{
				this._relHumidity = value;
			}
		}

		private decimal? _apparent;
		public virtual decimal? Apparent
		{
			get
			{
				return this._apparent;
			}
			set
			{
				this._apparent = value;
			}
		}

		private decimal? _rainFall;
		public virtual decimal? RainFall
		{
			get
			{
				return this._rainFall;
			}
			set
			{
				this._rainFall = value;
			}
		}

	}
}
