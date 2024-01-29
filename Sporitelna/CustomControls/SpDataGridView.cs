﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sporitelna.CustomControls
{
    class SpDataGridView : DataGridView
    {
		private void SetColumnOrder()
		{
			if (!SpDataGridViewSetting.Default.ColumnOrder.ContainsKey(this.Name))
				return;

			List<ColumnOrderItem> columnOrder =
				SpDataGridViewSetting.Default.ColumnOrder[this.Name];

			if (columnOrder != null)
			{
				var sorted = columnOrder.OrderBy(i => i.DisplayIndex);
				foreach (var item in sorted)
				{
					this.Columns[item.ColumnIndex].DisplayIndex = item.DisplayIndex;
					this.Columns[item.ColumnIndex].Visible = item.Visible;
					this.Columns[item.ColumnIndex].Width = item.Width;
				}
			}
		}
		//---------------------------------------------------------------------
		private void SaveColumnOrder()
		{
			if (this.AllowUserToOrderColumns)
			{
				List<ColumnOrderItem> columnOrder = new List<ColumnOrderItem>();
				DataGridViewColumnCollection columns = this.Columns;
				for (int i = 0; i < columns.Count; i++)
				{
					columnOrder.Add(new ColumnOrderItem
					{
						ColumnIndex = i,
						DisplayIndex = columns[i].DisplayIndex,
						Visible = columns[i].Visible,
						Width = columns[i].Width
					});
				}

				SpDataGridViewSetting.Default.ColumnOrder[this.Name] = columnOrder;
				SpDataGridViewSetting.Default.Save();
			}
		}
		//---------------------------------------------------------------------
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			SetColumnOrder();
		}
		//---------------------------------------------------------------------
		protected override void Dispose(bool disposing)
		{
			SaveColumnOrder();
			base.Dispose(disposing);
		}
	}
	//-------------------------------------------------------------------------
	internal sealed class SpDataGridViewSetting : ApplicationSettingsBase
	{
		private static SpDataGridViewSetting _defaultInstace =
			(SpDataGridViewSetting)ApplicationSettingsBase
			.Synchronized(new SpDataGridViewSetting());
		//---------------------------------------------------------------------
		public static SpDataGridViewSetting Default
		{
			get { return _defaultInstace; }
		}
		//---------------------------------------------------------------------
		// Because there can be more than one DGV in the user-application
		// a dictionary is used to save the settings for this DGV.
		// As key the name of the control is used.
		[UserScopedSetting]
		[SettingsSerializeAs(SettingsSerializeAs.Binary)]
		[DefaultSettingValue("")]
		public Dictionary<string, List<ColumnOrderItem>> ColumnOrder
		{
			get { return this["ColumnOrder"] as Dictionary<string, List<ColumnOrderItem>>; }
			set { this["ColumnOrder"] = value; }
		}
	}
	//-------------------------------------------------------------------------
	[Serializable]
	public sealed class ColumnOrderItem
	{
		public int DisplayIndex { get; set; }
		public int Width { get; set; }
		public bool Visible { get; set; }
		public int ColumnIndex { get; set; }
	}
}

