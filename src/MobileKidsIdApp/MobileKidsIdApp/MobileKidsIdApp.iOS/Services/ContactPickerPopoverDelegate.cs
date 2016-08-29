//using System;
//using System.Collections.Generic;
//using System.Text;
//using UIKit;

//namespace MobileKidsIdApp.iOS.Services
//{
//    internal class ContactPickerPopoverDelegate
//        : UIPopoverControllerDelegate
//    {
//        internal ContactPickerPopoverDelegate(ContactPickerDelegate pickerDelegate, ContactPickerController picker)
//        {
//            this.pickerDelegate = pickerDelegate;
//            this.picker = picker;
//        }

//        public override bool ShouldDismiss(UIPopoverController popoverController) => true;

//        public override void DidDismiss(UIPopoverController popoverController) =>
//            pickerDelegate.ContactPickerDidCancel(picker);

//        private readonly ContactPickerDelegate pickerDelegate;
//        private readonly ContactPickerController picker;
//    }
//}
