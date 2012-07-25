using System;

namespace DepDot
{
    public enum Control
    {
        RED,
        AMBER,
        GREEN,
        CLOSED,
        UNKNOWN
    };

    public enum Impact
    {
        S = 3,
        M = 6,
        L = 9
    };

    public class LineItem
    {
        public Control Control;
        public string Dependency;
        public string Direction;
        public string Owner;
        public int Id;
        public Impact Impact;

        ////Last Update	Schedule	Version	To prod	Project Name	ID	Direction	Ref. #	Dependency	Impact size	Control
        public DateTime LastUpdate;

        public string ProjectName;
        public string Reference;
        public string Schedule;
        public string Strategic;
        public DateTime ToProduction;
        public string Version;

        public bool Rendered = false;
        public int UniqueProjectId;
        public LineItem TargetLine;
    }
}