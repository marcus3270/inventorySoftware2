   M S B A M L   `   `   `  ����N  JMSBeverageRecordApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MSBeverageRecordAppMSBeverageRecordApp  5   	   &     MSBeverageRecordApp.CreateRecord   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:MSBeverageRecordApp     5   	     N� Title$  CreateRecord��5	   	   .��5
      (�  (� Stretch$
 Fill=�6   .��5   
   � ���	#FFFBF6F6$	��450��6&   $	��800��63   .+�5      �� $-��'Mississippi Beverage Equipment Tracking��6   $��40(�6F   $��Center=�6T   $��0,12,0,0q�6q   $	��Top=�6�   �� 5      $
��28px(�6   $��Create New Record��6$   $
��Left=�6@   $��
286,68,0,0q�6[   $	��Top=�6o   $��45��6�   $	��250��6�   �� 5      -   5         ��Name$ recordNumber��5      $
��Left=�6S   $��286,118,0,0q�6n    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $��60��6�   $��30��6�   $��Center=�6�   �� 5      -   5         ��Name$ IDtxtSearchPlaceholder��5      $	��ID#��64   
������  J� Opacity$	 0.5Q�6[    J� IsHitTestVisible$ False��6i   $
��Left=�6�   $��30��6�   $��286,118,0,0q�6�   $	��Top=�6�   $��49��6�    J� RenderTransformOrigin$ 	0.551,0.8&�6�   �� 5      -   5         ��Name$ cboCategory��5      $
��Left=�6.   $��206,159,0,0q�6I   	 �� Text$	 Category��6r   $	��Top=�6�   $	��140��6�   
 �� 
IsEditable$

 True��6�    �� 
IsReadOnly$
 True��6�   $|�False��6�   $��30��6�   �� 5      -   5        $ cboManufacturer��5      $
��Left=�61   $��206,205,0,0q�6L   $	 Manufacturer��6u   $	��Top=�6�   $	��140��6�   $

 True��6�   $
 True��6�   $|�False��6�   $��30��6�   �� 5      -   5        $ txtModel��5      $
��Left=�6L   $��206,246,0,0q�6g   $
 Wrap=�6|   $	��Top=�6�   $	��140��6�   $��30��6�   $��Center=�6�   �� 5      -   5        $ modeltxtSearchPlaceholder��5      $��Model#��67   
������ $	 0.5Q�6a   $ False��6o   $
��Left=�6�   $��30��6�   $��206,246,0,0q�6�   $	��Top=�6�   $��48��6�   �� 5      -   5        $ txtSerialNumber��5      $
��Left=�6[   $��206,297,0,0q�6v   $
 Wrap=�6�   $	��Top=�6�   $	��140��6�   $��30��6�   $��Center=�6�   �� 5      -   5        $  serialtxtSearchPlaceholder��5      $��Serial#��68   
������ $	 0.5Q�6c   $ False��6q   $
��Left=�6�   $��31��6�   $��206,297,0,0q�6�   $	��Top=�6�   $��48��6�   (  "System.Windows.Controls.DatePicker  5      -	   5          Name$ PurchaseDate��5      $��Right=�6/   $��0,343,454,0q�6K   $	��Top=�6`   $��30��6x   $	��140��6�   �� 5      -
   5        $ txtCost��5      $
��Left=�6J   $��206,388,0,0q�6e   $
 Wrap=�6z   $	��Top=�6�   $	��140��6�   $��30��6�   $��Center=�6�   �� 5      -   5        $ costtxtSearchPlaceholder��5      $
��Cost��66   
������ $	 0.5Q�6^   $ False��6l   $
��Left=�6�   $��30��6�   $��210,388,0,0q�6�   $	��Top=�6�   $��48��6�   $ 0.603,0.647&�6�   z�5      V� 5       .~�5!      �� �� 5"      �� 5#       �� Angle$ -0.57Q�6*   T� 5$       T� X$ 0.045Q�6-    T� Y$ -0.05Q�67   5%      5'      �� 5)      -   5        $ cboLocation��5)      $
��Left=�61   $��441,159,0,0q�6L   $	 Location��6u   $	��Top=�6�   $	��140��6�   $

 True��6�   $
 True��6�   $|�False��6�   $��30��6�   �� 5+      -   5        $ txtSubLocation��5+      $��Right=�6X   $��0,205,219,0q�6t   $
 Wrap=�6�   $	��Top=�6�   $	��140��6�   $��30��6�   $��Center=�6�   �� 5,      -   5        $% subLocationtxtSearchPlaceholder��5,      $��Sub Location (optional)��6=   
������ $	 0.5Q�6x   $ False��6�   $
��Left=�6�   $��30��6�   $��441,205,0,0q�6�   $	��Top=�6�   $	��140��6�   �� 5.      -   5        $��Submit��5.      $
��Left=�6&   $��461,388,0,0q�6A   $	��Top=�6V   $��30��6n   $	��100��6z   $ 0.54,1&�6�   �� 5/      $��NewRecord ID��6   $
��Left=�6+   $��30��6F   $��192,118,0,0q�6R   $	��Top=�6g   $��89��6   51      52      53      