using System;

using Foundation;
using ClockKit;

namespace OVSaldo.ios.watchExtension
{
    [Register("ComplicationController")]
    public class ComplicationController : CLKComplicationDataSource
    {
        protected ComplicationController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic
        }

        #region Timeline Configuration

        public override void GetSupportedTimeTravelDirections(CLKComplication complication, Action<CLKComplicationTimeTravelDirections> handler)
        {
            handler(CLKComplicationTimeTravelDirections.Forward | CLKComplicationTimeTravelDirections.Backward);
        }

        public override void GetTimelineStartDate(CLKComplication complication, Action<NSDate> handler)
        {
            handler(null);
        }

        public override void GetTimelineEndDate(CLKComplication complication, Action<NSDate> handler)
        {
            handler(null);
        }

        public override void GetPrivacyBehavior(CLKComplication complication, Action<CLKComplicationPrivacyBehavior> handler)
        {
            handler(CLKComplicationPrivacyBehavior.ShowOnLockScreen);
        }

        #endregion

        #region Timeline Population

        public override void GetCurrentTimelineEntry(CLKComplication complication, Action<CLKComplicationTimelineEntry> handler)
        {
            // Call the handler with the current timeline entry
            handler(null);
        }

        public override void GetTimelineEntriesBeforeDate(CLKComplication complication, NSDate beforeDate, nuint limit, Action<CLKComplicationTimelineEntry[]> handler)
        {
            // Call the handler with the timeline entries prior to the given date
            handler(null);
        }

        public override void GetTimelineEntriesAfterDate(CLKComplication complication, NSDate afterDate, nuint limit, Action<CLKComplicationTimelineEntry[]> handler)
        {
            // Call the handler with the timeline entries after to the given date
            handler(null);
        }

        #endregion

        #region Placeholder Templates

        public override void GetLocalizableSampleTemplate(CLKComplication complication, Action<CLKComplicationTemplate> handler)
        {
            // This method will be called once per supported complication, and the results will be cached
            handler(null);
        }

        #endregion
    }
}

