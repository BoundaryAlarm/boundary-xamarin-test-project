using System;
using System.Collections.Generic;
using code_test.common.Models;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;

namespace code_test.Droid.TemplateSelectors
{
    public class UsersTemplateSelector : IMvxTemplateSelector
    {
        public int ItemTemplateId { get; set; }
        
        private readonly Dictionary<Type, int> _typeDictionary = new Dictionary<Type, int>
        {
            [typeof(User)] = Resource.Layout.users_item
        };
        
        public int GetItemViewType(object forItemObject)
        {
            return _typeDictionary[forItemObject.GetType()];
        }

        public int GetItemLayoutId(int fromViewType)
        {
            return fromViewType;
        }
    }
}