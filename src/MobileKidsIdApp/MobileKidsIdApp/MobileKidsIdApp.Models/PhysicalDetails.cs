﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class PhysicalDetails : BaseTypes.BusinessBase<PhysicalDetails>
    {
        public static readonly PropertyInfo<string> HeightProperty = RegisterProperty<string>(c => c.Height);
        public string Height
        {
            get { return GetProperty(HeightProperty); }
            set { SetProperty(HeightProperty, value); }
        }

        public static readonly PropertyInfo<string> WeightProperty = RegisterProperty<string>(c => c.Weight);
        public string Weight
        {
            get { return GetProperty(WeightProperty); }
            set { SetProperty(WeightProperty, value); }
        }

        public static readonly PropertyInfo<DateTime> MeasurementDateProperty = RegisterProperty<DateTime>(c => c.MeasurementDate);
        public DateTime MeasurementDate
        {
            get { return GetProperty(MeasurementDateProperty); }
            set { LoadProperty(MeasurementDateProperty, value); }
        }

        public static readonly PropertyInfo<string> HairColorProperty = RegisterProperty<string>(c => c.HairColor);
        public string HairColor
        {
            get { return GetProperty(HairColorProperty); }
            set { SetProperty(HairColorProperty, value); }
        }

        public static readonly PropertyInfo<string> HairStyleProperty = RegisterProperty<string>(c => c.HairStyle);
        public string HairStyle
        {
            get { return GetProperty(HairStyleProperty); }
            set { SetProperty(HairStyleProperty, value); }
        }

        public static readonly PropertyInfo<string> EyeColorProperty = RegisterProperty<string>(c => c.EyeColor);
        public string EyeColor
        {
            get { return GetProperty(EyeColorProperty); }
            set { SetProperty(EyeColorProperty, value); }
        }

        public static readonly PropertyInfo<bool> EyeContactsProperty = RegisterProperty<bool>(c => c.EyeContacts);
        public bool EyeContacts
        {
            get { return GetProperty(EyeContactsProperty); }
            set { SetProperty(EyeContactsProperty, value); }
        }

        public static readonly PropertyInfo<bool> EyeGlassesProperty = RegisterProperty<bool>(c => c.EyeGlasses);
        public bool EyeGlasses
        {
            get { return GetProperty(EyeGlassesProperty); }
            set { SetProperty(EyeGlassesProperty, value); }
        }

        public static readonly PropertyInfo<string> SkinToneProperty = RegisterProperty<string>(c => c.SkinTone);
        public string SkinTone
        {
            get { return GetProperty(SkinToneProperty); }
            set { SetProperty(SkinToneProperty, value); }
        }

        public static readonly PropertyInfo<string> RacialEthnicIdentityProperty = RegisterProperty<string>(c => c.RacialEthnicIdentity);
        public string RacialEthnicIdentity
        {
            get { return GetProperty(RacialEthnicIdentityProperty); }
            set { SetProperty(RacialEthnicIdentityProperty, value); }
        }

        public static readonly PropertyInfo<string> GenderProperty = RegisterProperty<string>(c => c.Gender);
        public string Gender
        {
            get { return GetProperty(GenderProperty); }
            set { SetProperty(GenderProperty, value); }
        }

        public static readonly PropertyInfo<string> GenderIdentityProperty = RegisterProperty<string>(c => c.GenderIdentity);
        public string GenderIdentity
        {
            get { return GetProperty(GenderIdentityProperty); }
            set { SetProperty(GenderIdentityProperty, value); }
        }

        protected override void Child_Create()
        {
            MeasurementDate = DateTime.Today;
        }

        private void Child_Fetch(DataAccess.DataModels.PhysicalDetails details)
        {
            if (details == null) return;
            using (BypassPropertyChecks)
            {
                Height = details.Height;
                Weight = details.Weight;
                MeasurementDate = details.MeasurementDate;
                HairColor = details.HairColor;
                HairStyle = details.HairStyle;
                EyeColor = details.EyeColor;
                EyeGlasses = details.EyeGlasses;
                EyeContacts = details.EyeContacts;
                SkinTone = details.SkinTone;
                RacialEthnicIdentity = details.RacialEthnicIdentity;
                Gender = details.Gender;
                GenderIdentity = details.GenderIdentity;
            }
        }

        private void Child_Insert(DataAccess.DataModels.PhysicalDetails details)
        {
            Child_Update(details);
        }

        private void Child_Update(DataAccess.DataModels.PhysicalDetails details)
        {
            using (BypassPropertyChecks)
            {
                details.Height = Height;
                details.Weight = Weight;
                details.MeasurementDate = MeasurementDate;
                details.HairColor = HairColor;
                details.HairStyle = HairStyle;
                details.EyeColor = EyeColor;
                details.EyeGlasses = EyeGlasses;
                details.EyeContacts = EyeContacts;
                details.SkinTone = SkinTone;
                details.RacialEthnicIdentity = RacialEthnicIdentity;
                details.Gender = Gender;
                details.GenderIdentity = GenderIdentity;
            }
        }
    }
}
