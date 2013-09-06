using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.SyntacticAnalyzer
{
    /// <summary>
    /// 项目,在产生式的右部适当的位置添加一个圆点
    /// </summary>
    public class Item
    {
        /// <summary>
        /// 是非为核心项
        /// </summary>
        public bool IsCore { get; set; }
        /// <summary>
        /// 向前搜索符
        /// </summary>
        public List<VertexTerminator> FowardSearch { get; set; }
        /// <summary>
        /// 关联的产生式
        /// </summary>
        public GrammerRule Rule { get; set; }
        /// <summary>
        /// 项目中圆点的位置
        /// </summary>
        public int DotPosition { get; set; }
        /// <summary>
        /// 项目类型
        /// </summary>
        public ProjectType Type
        {
            get
            {
                if (DotPosition == Rule.Right.Count)
                    return ProjectType.Convention;
                if (DotPosition == 0)
                    return ProjectType.Start;
                return ProjectType.Shift;
            }
        }
        /// <summary>
        /// 是否为相等的项目
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public bool IsSameItemWith(Item project)
        {
            return this.Rule == project.Rule && this.DotPosition == project.DotPosition;
        }
        /// <summary>
        /// 是否为完全等同的项目，向前收索符也一致
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public bool isCompleteSameWith(Item project)
        {
            if (!this.IsSameItemWith(project))
                return false;
            foreach (var vt in this.FowardSearch)
            {
                if (!project.FowardSearch.Contains(vt))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 将制定project中的向前搜索符合并到当前的project，返回合并后的结果
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public List<VertexTerminator> CombineFowardSearch(Item project)
        {
            foreach (var forward in project.FowardSearch)
            {
                if (!this.FowardSearch.Contains(forward))
                    this.FowardSearch.Add(forward);
            }
            return this.FowardSearch;
        }
        /// <summary>
        /// 返回圆点后的第index个字符
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Vertex AfterDot(int index)
        {
            if (index + DotPosition >= Rule.Right.Count)
                return null;
            return this.Rule.Right[index + DotPosition];
        }
        /// <summary>
        /// 移进，圆点后移
        /// </summary>
        /// <returns></returns>
        public Item Shift()
        {
            if (this.Type == ProjectType.Convention)
                throw new Exception("不能移进规约项");
            return new Item()
            {
                Rule = this.Rule,
                DotPosition = this.DotPosition + 1,
                FowardSearch = new List<VertexTerminator>(this.FowardSearch)
            };
        }

        public override string ToString()
        {
            String ret = Rule.Left + "->";
            foreach (Vertex v in Rule.Right)
            {
                ret += v.ToString();
            }
            ret.Insert(DotPosition, ".");
            ret += "   , ";
            foreach (var v in this.FowardSearch)
            {
                ret += v.ToString() + "/";
            }
            ret = ret.Remove(ret.Length - 1);
            return ret;
        }
    }

    public enum ProjectType
    {
        /// <summary>
        /// 移进项
        /// </summary>
        Shift,
        /// <summary>
        /// 规约项
        /// </summary>
        Convention,
        /// <summary>
        /// 原始产生项
        /// </summary>
        Start
    }

}
