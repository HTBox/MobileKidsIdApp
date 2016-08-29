//using MobileKidsIdApp.ViewModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using UIKit;

//namespace MobileKidsIdApp.iOS.Services
//{
//    public class ContactPickerImplementation
//    {

//        public Task<ContactInfo> PickContactAsync()
//        {
//            UIWindow window = UIApplication.SharedApplication.KeyWindow;
//            if (window == null)
//                throw new InvalidOperationException("There's no current active window");

//            UIViewController viewController = window.RootViewController;

//            if (viewController == null)
//            {
//                window = UIApplication.SharedApplication.Windows.OrderByDescending(w => w.WindowLevel).FirstOrDefault(w => w.RootViewController != null);
//                if (window == null)
//                    throw new InvalidOperationException("Could not find current view controller");
//                else
//                    viewController = window.RootViewController;
//            }

//            while (viewController.PresentedViewController != null)
//                viewController = viewController.PresentedViewController;

//            ContactPickerDelegate ndelegate = new ContactPickerDelegate(viewController);
//            var od = Interlocked.CompareExchange(ref pickerDelegate, ndelegate, null);
//            if (od != null)
//                throw new InvalidOperationException("Only one operation can be active at at time");

//            var picker = SetupController(ndelegate, sourceType, mediaType, options);

//            // TODO : Fully implement the Popover lines below and in the referenced delegate classes for tablets if desired.
//            //if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad && sourceType == UIImagePickerControllerSourceType.PhotoLibrary)
//            //{
//            //    ndelegate.Popover = new UIPopoverController(picker);
//            //    ndelegate.Popover.Delegate = new ContactPickerPopoverDelegate(ndelegate, picker);
//            //    ndelegate.DisplayPopover();
//            //}
//            //else
//                viewController.PresentViewController(picker, true, null);

//            return ndelegate.Task.ContinueWith(t =>
//            {
//                //if (popover != null)
//                //{
//                //    popover.Dispose();
//                //    popover = null;
//                //}

//                Interlocked.Exchange(ref pickerDelegate, null);
//                return t;
//            }).Unwrap();
//        }
//    }
//}
