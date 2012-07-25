using System;
using System.Collections.Generic;
using System.Text;

namespace DepDot
{
    public class DotWriter
    {
        private List<LineItem> _lines;

        private int _FilterControl;
        public int FilterControl
        {
            get
            {
                return _FilterControl;
            }
            set
            {
                _FilterControl = value;
            }
        }

        public bool NoFrom;
        private bool _NoFrom { get }

        public DotWriter(List<LineItem> lines)
        {
            _lines = lines;
        }

        public static StringBuilder GenerateDot(List<LineItem> lines, bool noFrom, bool rankFix, bool includePast, string filterStrategic, string filterSchedule, int filterControl, string filterOwner, bool filterDate, DateTime filterDateFrom, DateTime filterDateTo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("digraph testdiagram {");

            //write schedules and versions
            List<string> schedules = new List<string>();
            foreach (LineItem line in lines)
            {
                if (!schedules.Contains(line.Schedule + " " + line.Version))
                {
                    schedules.Add(line.Schedule + " " + line.Version);
                }
            }

            string weight, control = "", scheduleColor = "", style = "";

            sb.AppendLine("node[shape = diamond];");
            sb.Append("{ rank = same; ");
            if (rankFix) sb.Append("ranks ");
            foreach (string schedule in schedules)
            {
                sb.Append("s" + schedules.IndexOf(schedule).ToString() + " [label=\"" + schedule + "\"] ");
            }
            sb.AppendLine("}");

            sb.AppendLine("node[shape = box];");

            UpdateProjectIds(lines);

            //Projects (nodes)
            foreach (LineItem line in lines)
            {
                if (!IsFiltered(line, includePast, filterStrategic, filterSchedule, filterControl, filterOwner, filterDate, filterDateFrom, filterDateTo))
                {
                    sb.AppendLine("p" + line.UniqueProjectId + " [label=\"" + line.ProjectName + "\"" + scheduleColor + "]; ");
                    line.Rendered = true;
                }
            }

            //Schedule - Project (edge)
            foreach (LineItem line in lines)
            {
                if (!IsFiltered(line, includePast, filterStrategic, filterSchedule, filterControl, filterOwner, filterDate, filterDateFrom, filterDateTo))
                {
                    if (!OutputContains("s" + schedules.IndexOf(line.Schedule + " " + line.Version).ToString() + " -> p" + line.UniqueProjectId, sb))
                    {
                        sb.AppendLine("s" + schedules.IndexOf(line.Schedule + " " + line.Version).ToString() + " -> p" + line.UniqueProjectId + " [arrowhead=none color=gray88];");
                    }
                }
            }

            //UpdateSchedules(lines);

            //Project - Project (edge)
            foreach (LineItem line in lines)
            {
                weight = " weight=" + Convert.ToString((int)line.Impact) + " ";
                switch (line.Control)
                {
                    case Control.RED:
                        control = " control=red color=red";
                        break;
                    case Control.AMBER:
                        control = " control=amber color=orange ";
                        break;
                    case Control.GREEN:
                        control = " control=green color=green ";
                        break;
                    case Control.CLOSED:
                        control = " control=closed color=gray ";
                        break;
                    case Control.UNKNOWN:
                        control = " control=unspecified color=gray ";
                        break;
                }

                switch (line.Direction)
                {
                    case "TO":
                        if (line.TargetLine != null)
                        {
                            sb.AppendLine("p" + line.UniqueProjectId + " -> " + "p" + line.TargetLine.Id + " [" + control + weight + style + " label=" + line.Id.ToString() + "];");
                        }
                        else
                        {
                            sb.AppendLine("u" + Sanitise(line.Dependency) + " [label=\"" + line.Dependency + "?\"]; ");
                            sb.AppendLine("p" + line.UniqueProjectId + " -> " + "u" + Sanitise(line.Dependency) + " [" + control + weight + style + " label=" + line.Id.ToString() + "];");
                        }
                        break;
                    case "FROM":
                        if (line.TargetLine != null)
                        {
                            sb.AppendLine("p" + line.UniqueProjectId + " -> p" + line.TargetLine.Id + " [" + control + weight + style + " dir=back label=" + line.Id.ToString() + "];");
                        }
                        else
                        {
                            sb.AppendLine("u" + Sanitise(line.Dependency) + " [label=\"" + line.Dependency + "?\"]; ");
                            sb.AppendLine("p" + line.UniqueProjectId + " -> " + "u" + Sanitise(line.Dependency) + " [" + control + weight + style + " dir=back label=" + line.Id.ToString() + "];");
                        }
                        break;
                    case "INTER":
                        break;
                    default:
                        break;
                }
            }

            sb.AppendLine("}");
            return (sb);
        }

        private static List<LineItem> UpdateProjectIds(List<LineItem> lines)
        {
            foreach (LineItem line in lines)
            {
                //Get unique project Id for this line
                int uniqueId = -1;
                uniqueId = GetUniqueProjectId(line.Schedule, line.Version, line.ProjectName, lines);

                if (uniqueId > -1 && uniqueId != line.Id)
                {
                    line.UniqueProjectId = uniqueId;
                }
                else
                {
                    line.UniqueProjectId = line.Id;
                }

                LineItem targetLine = GetLine(line.Reference, lines);

                //Get unique project Id for target line
                uniqueId = -1;
                if (targetLine != null)
                {
                    line.TargetLine = targetLine;

                    uniqueId = GetUniqueProjectId(targetLine.Schedule, targetLine.ProjectName, lines);

                    if (uniqueId > -1 && uniqueId != targetLine.Id)
                    {
                        line.TargetLine = GetLine(uniqueId, lines);
                    }
                }
            }
            return lines;
        }

        private static List<LineItem> UpdateSchedules(List<LineItem> lines)
        {
            foreach (LineItem line in lines)
            {
                switch (line.Schedule.ToLower())
                {
                    case "mnx":
                        line.Schedule = "mnx";
                        break;
                    case "etickets":
                    case "e-tickets":
                        line.Schedule = "etickets";
                        break;
                    case "vm":
                    case "venuemaster":
                        line.Schedule = "venuemaster";
                        break;
                    case "vmt":
                    case "tournaments":
                        line.Schedule = "tournaments";
                        break;
                    case "tms":
                        line.Schedule = "tms";
                        break;
                    case "mfol":
                        line.Schedule = "mfol";
                        break;
                    case "wmr":
                        line.Schedule = "wmr";
                        break;
                    case "newmarkets":
                    case "new market":
                    case "new markets":
                        line.Schedule = "newmarkets";
                        break;
                    case "asra":
                        line.Schedule = "asra";
                        break;
                    case "mobile":
                        line.Schedule = "mobile";
                        break;
                    case "ln.xx":
                        line.Schedule = "lnxx";
                        break;
                    case "tickets now":
                    case "ticketsnow":
                        line.Schedule = "ticketsnow";
                        break;
                    case "techops":
                        line.Schedule = "techops";
                        break;
                    case "liveinsight":
                    case "li":
                        line.Schedule = "liveinsight";
                        break;
                    case "tmol":
                        line.Schedule = "tmol";
                        break;
                    case "gmi":
                    case "gmi (ticketsnow)":
                        line.Schedule = "gmi";
                        break;
                    case "tmm":
                        line.Schedule = "tmm";
                        break;
                    default:
                        line.Schedule = "other";
                        break;
                }
            }
            return lines;
        }

        private static bool IsFiltered(LineItem li, bool includePast, string filterStrategic, string filterSchedule, int filterControl, string filterOwner, bool filterDate, DateTime filterDateFrom, DateTime filterDateTo)
        {
            //ignore items that don't match the control filter
            if (filterControl>=0)
            {
                if ((int)li.Control != filterControl)
                {
                    return true;
                }
            }
            
            //ignore past dependencies
            if (!includePast)
            {
                if (DateTime.Now.AddMonths(-1) >= li.ToProduction)
                {
                    return true;
                }
            }

            //ignore items that don't match the strategy filter
            if (!string.IsNullOrEmpty(filterStrategic))
            {
                if (li.Strategic != filterStrategic)
                {
                    return true;
                }
            }

            //ignore items that don't match the schedule filter
            if (!string.IsNullOrEmpty(filterSchedule))
            {
                if (li.Schedule != filterSchedule)
                {
                    return true;
                }
            }

            //ignore items that don't match the owner filter
            if (!string.IsNullOrEmpty(filterOwner))
            {
                if (li.Owner != filterOwner)
                {
                    return true;
                }
            }

            //ignore dates outside of the date range
            if (filterDate)
            {
                if (li.ToProduction <= filterDateFrom || li.ToProduction >= filterDateTo)
                {
                    return true;
                }
            }

            return false;
        }

        public static int GetUniqueProjectId(string projectName, List<LineItem> lines)
        {
            foreach (LineItem line in lines)
            {
                if (line.ProjectName.Trim().ToLower() == projectName.Trim().ToLower())
                {
                    return line.Id;
                }
            }
            return -1;
        }

        public static int GetUniqueProjectId(string scheduleName, string projectName, List<LineItem> lines)
        {
            foreach (LineItem line in lines)
            {
                if (line.ProjectName.Trim().ToLower() == projectName.Trim().ToLower() &&
                    line.Schedule.Trim().ToLower() == scheduleName.Trim().ToLower())
                {
                    return line.Id;
                }
            }
            return -1;
        }

        public static int GetUniqueProjectId(string scheduleName, string version, string projectName, List<LineItem> lines)
        {
            foreach (LineItem line in lines)
            {
                if (string.IsNullOrEmpty(line.ProjectName)) line.ProjectName = string.Empty;
                if (string.IsNullOrEmpty(line.Schedule)) line.Schedule = string.Empty;
                if (string.IsNullOrEmpty(line.Version)) line.Version = string.Empty;

                if (string.IsNullOrEmpty(projectName)) projectName = string.Empty;
                if (string.IsNullOrEmpty(scheduleName)) scheduleName = string.Empty;
                if (string.IsNullOrEmpty(version)) version = string.Empty;

                if (line.ProjectName.Trim().ToLower() == projectName.Trim().ToLower() &&
                    line.Schedule.Trim().ToLower() == scheduleName.Trim().ToLower() &&
                    line.Version.Trim().ToLower() == version.Trim().ToLower())
                {
                    return line.Id;
                }
            }
            return -1;
        }

        public static string Sanitise(string text)
        {
            if (string.IsNullOrEmpty(text)) return null;

            char[] arr = text.ToCharArray();

            arr = Array.FindAll<char>(arr, (c => (char.IsLetterOrDigit(c))));
            text = new string(arr);

            return text;
        }

        private static LineItem GetLine(int Id, List<LineItem> lines)
        {
            foreach (LineItem line in lines)
            {
                if (line.Id.ToString() == Id.ToString())
                {
                    return line;
                }
            }
            return null;
        }

        private static LineItem GetLine(string Id, List<LineItem> lines)
        {
            int targetId = 0;
            int.TryParse(Id, out targetId);
            if (targetId > 0)
            {
                return GetLine(targetId, lines);
            }
            else
            {
                return null;
            }
        }

        private static bool OutputContains(string textToFind, StringBuilder sb)
        {
            return (sb.ToString().Contains(textToFind));
        }
    }
}