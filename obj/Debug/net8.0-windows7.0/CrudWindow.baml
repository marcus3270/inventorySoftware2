   M S B A M L   `   `   `  ����N  JMSBeverageRecordApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MSBeverageRecordAppMSBeverageRecordApp  5   	   b ^Microsoft.VisualBasic.Core, Version=13.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3aaGclr-namespace:Microsoft.VisualBasic;assembly=Microsoft.VisualBasic.CoreMicrosoft.VisualBasic 5   	   $    MSBeverageRecordApp.CrudWindow   5      A =Wpf.Ui, Version=3.0.3.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:MSBeverageRecordApp     5   	   _VisualBasicGclr-namespace:Microsoft.VisualBasic;assembly=Microsoft.VisualBasic.Core     5   	     N� Title$  
CrudWindow��5
   	   .��5      (� .��5      � $	��510��6   $	��890��6    � RowDefinitions 5   
   �� 5      $	��35* �6   6+   �� 5      $
��200* �6   6,   �� 5      $	��25* �6   6+    � ColumnDefinitions 5   
   �� 5      $	��50* �6   6-   �� 5      $	��50* �6   6-   .+�5   
   o� -   5        $��fileMenu��5      $y�	Collapsed=�6   $
��Left=�66   $	��956��6Q   
�������$��2��6p   5"      &   System.Windows.Controls.DataGrid  5$   
   -   5          Name$ MSBeverageRecordGrid��5$   (   $y�Visible=�6   $��
10,5,10,13q�6F      
IsReadOnly$
 True��6Z      CanUserAddRows$ False��6l      AutoGenerateColumns$ False��6�   $��3��6�   $��1��6�      Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 50 61   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6<   �� *	record_id+6\     5'      $ category��6%   $		 100 67   
 6C   �� *categoryName+6f     5(      $ company��6%   $		 100 66   
 6B   �� *companyName+6d     5)      $ model��6%   $		 100 64   
 6@   �� *model+6\     5*      $ serial��6%   $		 100 65   
 6A   �� *serial+6^     5+      $ purchase date��6%   $		 100 6<   
 6H   �� *purchase_date+ �� StringFormat$ {0: MM/dd/yy}��6�     5,      $
 cost��6%   $		 100 63   
 6?   �� *cost+6Z     5-      $ location��6%   $		 100 67   
 6C   �� *locationName+6f     5.      $ sub-location��6%   $		 150 6;   
 6G   �� *sub_location+6j    � 	Resources 51      )  #System.Windows.Controls.DataGridRow �� 
TargetType��%E   '        �� 52      "  6   .�53      -   5        54      55      56      �� 59   
   $y�Visible=�6   $
��22px(�6&   $"��Mississippi Beverage Records��66   $��Center=�6]   $��32,5,0,0q�6z   $	��Top=�6�   $��47��6�   $	��300��6�   $��2��6�   �� 5;   
   -   5         ��Name$ consoleOutput��5;   '   $y�Visible=�6   $
��Left=�6>   $��
166,22,0,0q�6Y    �� TextWrapping$
 Wrap=�6m   $��TextBox��6�   $	��Top=�6�   $	��654��6�   $��3��6�   $��2��6�   $��18��6�   �� 5<   
   -   5         ��Name$ Filter��5<   (   $y�Visible=�6   $��29,55,138,22q�68   $��0��6N   $��2��6^   .@�5=      �� $��Select a Filter��6    �� 
IsSelected$
 True��65   �� 5>      $��
Category 1��6   �� 5?      $��
Category 2��6   �� 5@      $��
Category 3��6   �� 5A      $��
Category 4��6   �� 5B      $��
Category 5��6   5C      �� 5E   
   -   5        $��lblEdit��5E      $��Edit Record��6   $
��Left=�65   $��30(�6P   $
��Bold"�6^   $��1��6q   $	��221��6�   $y�Hidden=�6�   �� 5H   
   -   5         ��Name$ spLabels��5H      $��1��6'   $y�Hidden=�64   
�������$
��Left=�6[   $	��184��6v   $	��Top=�6�   $��
250,10,0,0q�6�   $	��418��6�   $��2��6�   .+�5I      �� $��Category Name��6   $��0,5,0,0q�6,   $��46��6=   $	��184��6I   $��Center=�6U   $
��Left=�6y   $	��Top=�6�   $��Center=�6�   �� 5J      $��Company Name��6   $
��Left=�6+   $��0,5,0,0q�6F   $��46��6W   $y�Visible=�6c   $	��184��6x   $��Center=�6�   $	��Top=�6�   $��Center=�6�   �� 5K      $��Model��6   $
��Left=�6$   $��0,5,0,0q�6?   $��46��6P   $	��184��6\   $��RightToLeft=�6h   $��Center=�6�   $	��Top=�6�   $��Center=�6�   �� 5L      $��Serial��6   $��46��6%   $	��184��61   $��RightToLeft=�6=   $��Center=�6Y   $��Center=�6}   �� 5M      $��Purchase Date��6   $
��Left=�6,   $��0,5,0,0q�6G   $��46��6X   $	��184��6d   $��Center=�6p   $��Center=�6�   �� 5N      $
��Cost��6   $
��Left=�6#   $��0,5,0,0q�6>   $��46��6O   $	��184��6[   $��Center=�6g   $��Center=�6�   �� 5O      $��Location��6   $
��Left=�6'   $��0,5,0,0q�6B   $��46��6S   $	��184��6_   $��Center=�6k   $��Center=�6�   �� 5P      $��Sub-Location��6   $��46��6+   $	��184��67   $��Center=�6C   $��Center=�6g   5Q      �� 5R   
   -   5        $ spText��5R      $y�Hidden=�6%   
�������$
��Left=�6L   $	��206��6g   $��	70,10,0,0q�6s   $	��Top=�6�   $��2��6�   $��1��6�   $	��418��6�   .+�5S      �� -	   5        $ 
txbCatName��5S       �� Text$ TextBox��6+   $	��206��6:   $��46��6F   $��Center=�6R   �� 5T      -
   5        $ txbCompName��5T      $��0,5,0,0q�6-   $ TextBox��6>   $	��206��6M   $��46��6Y   $
��Left=�6e   $��Center=�6�   �� 5U      -   5        $��txbModel��5U   1   $
��Left=�6   $��0,5,0,0q�6A   $
 Wrap=�6R   $�� ��6f   $��46��6n   $��Center=�6z   $	��206��6�   �� 5V      -   5        $��	txbSerial��5V   1   $
��Left=�6   $��0,5,0,0q�6B   $
 Wrap=�6S   $�� ��6g   $��46��6o   $��Center=�6{   $	��206��6�   (  "System.Windows.Controls.DatePicker  5W      -   5          Name$ txbPurchaseDate��5X   O   $
��Left=�64   $��0,5,0,0q�6h      Text$ TextBox��6y   $	��206��6�   $��46��6�   $	��Top=�6�   $��Center=�6�      SelectedDate 6   �� *purchase_date+6�   �� 5Y      -   5        $��txbCost��5Y   1   $
��Left=�6   $��0,5,0,0q�6@   $��46��6Q   $
 Wrap=�6]   $�� ��6q   $��Center=�6y   $	��206��6�   �� 5Z      -   5        $��txbLocation��5Z   2   $
��Left=�6   $��0,5,0,0q�6E   $ TextBox��6V   $	��Top=�6e   $	��206��6}   $��36��6�   $��Center=�6�   �� 5[      -   5        $��txbSubLocation��5[   1   $
��Left=�6   $��0,5,0,0q�6G   $
 Wrap=�6X   $�� ��6l   $	��Top=�6t   $��46��6�   $��Center=�6�   $	��206��6�   5\      �� 5]   
   -   5        $��	btnCancel��5]   !   $��1��6   $��Cancel��62   $
��Left=�6C   $��	318,0,0,0q�6^   $��2��6q   $��Center=�6~   $��32��6�   $��80��6�   $y�Hidden=�6�   6�   �� 5^   
   -   5        $��btnSave��5^   !   $��1��6   $
��Save��60   $
��Left=�6?   $��	173,0,0,0q�6Z   $��2��6m   $��Center=�6z   $��32��6�   $��78��6�   $y�Hidden=�6�   6�   5`      5a      5f      