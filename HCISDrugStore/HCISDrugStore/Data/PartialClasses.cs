using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCISDrugStore.Data
{
    public class PartialClasses
    {

    }
    public partial class GivenServiceD
    {
        private string _NISComment;
        public string NISComment
        {
            get
            {
                return this._NISComment;
            }
            set
            {
                if ((this._NISComment != value))
                {
                    this._NISComment = value;
                }
            }
        }

    }

    public partial class Person
    {
        private int _RelationOrder;
        public int RelationOrder
        {
            get
            {
                return this._RelationOrder;
            }
            set
            {
                if ((this._RelationOrder != value))
                {
                    this._RelationOrder = value;
                }
            }
        }
    }
}
