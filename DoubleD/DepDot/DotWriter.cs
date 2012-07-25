using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DepDot
{
    public class DotWriter
    {
        public List<LineItem> LineItems;
        public StringBuilder DotOutput;
        public bool NoFrom { get; set; }
        public bool RankFix { get; set; }
        public bool IncludePast { get; set; }
        public string FilterStrategic { get; set; }
        public string FilterSchedule { get; set; }
        public string FilterOwner { get; set; }
        public int FilterControl { get; set; }
        public bool FilterDate { get; set; }
        public DateTime FilterDateFrom { get; set; }
        public DateTime FilterDateTo { get; set; }

        public DotWriter()
        {
        }

        public DotWriter(List<LineItem> lines)
        {
            LineItems = lines;
        }

        public StringBuilder GenerateDot()
        {
            DotOutput = new StringBuilder();

            DotOutput.AppendLine("digraph testdiagram {");

            //write schedules and versions
            var schedules = new List<string>();
            foreach (LineItem line in LineItems.Where(line => !schedules.Contains(line.Schedule + " " + line.Version)))
            {
                schedules.Add(line.Schedule + " " + line.Version);
            }

            string control = "";
            const string scheduleColor = "";
            var style = "";

            DotOutput.AppendLine("node[shape = diamond];");
            DotOutput.Append("{ rank = same; ");
            if (RankFix) DotOutput.Append("ranks ");
            foreach (string schedule in schedules)
            {
                DotOutput.Append("s" + schedules.IndexOf(schedule).ToString() + " [label=\"" + schedule + "\"] ");
            }
            DotOutput.AppendLine("}");

            DotOutput.AppendLine("node[shape = box];");

            UpdateProjectIds();

            //Projects (nodes)
            foreach (LineItem line in LineItems)
            {
                if (!IsFiltered(line))
                {
                    DotOutput.AppendLine("p" + line.UniqueProjectId + " [label=\"" + line.ProjectName + "\"" +
                                         scheduleColor + "]; ");
                    line.Rendered = true;
                }
            }

            //Schedule - Project (edge)
            foreach (LineItem line in LineItems)
            {
                if (!IsFiltered(line))
                {
                    if (
                        !OutputContains(
                            "s" + schedules.IndexOf(line.Schedule + " " + line.Version).ToString() + " -> p" +
                            line.UniqueProjectId, DotOutput))
                    {
                        DotOutput.AppendLine("s" + schedules.IndexOf(line.Schedule + " " + line.Version).ToString() +
                                             " -> p" + line.UniqueProjectId + " [arrowhead=none color=gray88];");
                    }
                }
            }

            //UpdateSchedules(lines);

            //Project - Project (edge)
            foreach (LineItem line in LineItems)
            {
                string weight = " weight=" + Convert.ToString((int) line.Impact) + " ";
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
                            DotOutput.AppendLine("p" + line.UniqueProjectId + " -> " + "p" + line.TargetLine.Id + " [" +
                                                 control + weight + style + " label=" + line.Id.ToString() + "];");
                        }
                        else
                        {
                            DotOutput.AppendLine("u" + Sanitise(line.Dependency) + " [label=\"" + line.Dependency +
                                                 "?\"]; ");
                            DotOutput.AppendLine("p" + line.UniqueProjectId + " -> " + "u" + Sanitise(line.Dependency) +
                                                 " [" + control + weight + style + " label=" + line.Id.ToString() + "];");
                        }
                        break;
                    case "FROM":
                        if (line.TargetLine != null)
                        {
                            DotOutput.AppendLine("p" + line.UniqueProjectId + " -> p" + line.TargetLine.Id + " [" +
                                                 control + weight + style + " dir=back label=" + line.Id.ToString() +
                                                 "];");
                        }
                        else
                        {
                            DotOutput.AppendLine("u" + Sanitise(line.Dependency) + " [label=\"" + line.Dependency +
                                                 "?\"]; ");
                            DotOutput.AppendLine("p" + line.UniqueProjectId + " -> " + "u" + Sanitise(line.Dependency) +
                                                 " [" + control + weight + style + " dir=back label=" +
                                                 line.Id.ToString() + "];");
                        }
                        break;
                    case "INTER":
                        break;
                    default:
                        break;
                }
            }

            DotOutput.AppendLine("}");
            return (DotOutput);
        }

        private void UpdateProjectIds()
        {
            foreach (LineItem line in LineItems)
            {
                //Get unique project Id for this line
                int uniqueId = -1;
                uniqueId = GetUniqueProjectId(line.Schedule, line.Version, line.ProjectName);

                if (uniqueId > -1 && uniqueId != line.Id)
                {
                    line.UniqueProjectId = uniqueId;
                }
                else
                {
                    line.UniqueProjectId = line.Id;
                }

                LineItem targetLine = GetLine(line.Reference);

                //Get unique project Id for target line
                uniqueId = -1;
                if (targetLine != null)
                {
                    line.TargetLine = targetLine;

                    uniqueId = GetUniqueProjectId(targetLine.Schedule, targetLine.ProjectName);

                    if (uniqueId > -1 && uniqueId != targetLine.Id)
                    {
                        line.TargetLine = GetLine(uniqueId);
                    }
                }
            }
        }

        private void UpdateSchedules()
        {
            foreach (LineItem line in LineItems)
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
        }

        private bool IsFiltered(LineItem line)
            //, bool includePast, string filterStrategic, string filterSchedule, int filterControl, string filterOwner, bool filterDate, DateTime filterDateFrom, DateTime filterDateTo)
        {
            //ignore items that don't match the control filter
            if (FilterControl >= 0)
            {
                if ((int) line.Control != FilterControl)
                {
                    return true;
                }
            }

            //ignore past dependencies
            if (!IncludePast)
            {
                if (DateTime.Now.AddMonths(-1) >= line.ToProduction)
                {
                    return true;
                }
            }

            //ignore items that don't match the strategy filter
            if (!string.IsNullOrEmpty(FilterStrategic))
            {
                if (line.Strategic != FilterStrategic)
                {
                    return true;
                }
            }

            //ignore items that don't match the schedule filter
            if (!string.IsNullOrEmpty(FilterSchedule))
            {
                if (line.Schedule != FilterSchedule)
                {
                    return true;
                }
            }

            //ignore items that don't match the owner filter
            if (!string.IsNullOrEmpty(FilterOwner))
            {
                if (line.Owner != FilterOwner)
                {
                    return true;
                }
            }

            //ignore dates outside of the date range
            if (FilterDate)
            {
                if (line.ToProduction <= FilterDateFrom || line.ToProduction >= FilterDateTo)
                {
                    return true;
                }
            }

            return false;
        }

        public int GetUniqueProjectId(string projectName)
        {
            foreach (LineItem line in LineItems)
            {
                if (line.ProjectName.Trim().ToLower() == projectName.Trim().ToLower())
                {
                    return line.Id;
                }
            }
            return -1;
        }

        public int GetUniqueProjectId(string scheduleName, string projectName)
        {
            foreach (LineItem line in LineItems)
            {
                if (line.ProjectName.Trim().ToLower() == projectName.Trim().ToLower() &&
                    line.Schedule.Trim().ToLower() == scheduleName.Trim().ToLower())
                {
                    return line.Id;
                }
            }
            return -1;
        }

        public int GetUniqueProjectId(string scheduleName, string version, string projectName)
        {
            foreach (LineItem line in LineItems)
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

        public string Sanitise(string text)
        {
            if (string.IsNullOrEmpty(text)) return null;

            char[] arr = text.ToCharArray();

            arr = Array.FindAll<char>(arr, (c => (char.IsLetterOrDigit(c))));
            text = new string(arr);

            return text;
        }

        private LineItem GetLine(int Id)
        {
            foreach (LineItem line in LineItems)
            {
                if (line.Id.ToString() == Id.ToString())
                {
                    return line;
                }
            }
            return null;
        }

        private LineItem GetLine(string Id)
        {
            int targetId = 0;
            int.TryParse(Id, out targetId);
            if (targetId > 0)
            {
                return GetLine(targetId);
            }
            else
            {
                return null;
            }
        }

        private bool OutputContains(string textToFind, StringBuilder sb)
        {
            return (sb.ToString().Contains(textToFind));
        }
    }
}