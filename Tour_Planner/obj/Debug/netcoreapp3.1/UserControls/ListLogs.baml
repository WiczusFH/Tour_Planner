   M S B A M L   `   `   `  ����?  ;View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Tour_Planner.View.UserControlsTour_Planner.View.UserControls  5      D @ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:ViewModel;assembly=ViewModel	ViewModel 5      -    'Tour_Planner.View.UserControls.UserLogs   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:Tour_Planner.View.UserControls     5      @	viewModel*clr-namespace:ViewModel;assembly=ViewModel     5      .��5      �� $��RightToLeft=�6   .��5   
   �� $��LeftToRight=�6   $��10,10,10,10q�61   
�������  � DataContext  6Y   �� *listLogsViewModel+.+�5      �� .��6   	Filter:6   �� 5      -   5         ��Name$ filter��5      $
��Auto��6>   ��6&   �� *filter+6>   �� 5      �� 5       �� AlternationCount$	 100��6;   ��6   �� *	logList+��5      �� 5      .R�5      �� 
���iii�$��3q�63   ._�5      �� .+�5      �  � ColumnDefinitions 5      �� 5   "   $��* �63   �� 5   "   $��* �63   �� 5   "   $��* �63   �� 5   "   $��0.375* �63   �� 5   "   $��0.375* �63   .+�5!      �� $��0��6%   
�������$��2q�6L   ._�5"   "   �� ��6,   �� *
logTitle+5#      �� 5$      $��1��6%   
�������$��2q�6L   ._�5%   "   �� ��6,   �� *	routeName+5&      �� 5'      $��2��6%   
�������$��2q�6L   ._�5(   "   �� ��6,   �� *
dateString+5)      �� 5+      $��3��6%   
�������$��2q�6L   ._�5,   "   ��   5-   %   ��  �� RelativeSource ��  �� AncestorType 
StackPanel �� AncestorLevel$ 2�� �� Path$ DataContext���5.   9   �� *updateMapCommand+��5/   )   �� $% (ItemsControl.AlternationIndex)� �� *TemplatedParent+ �� StringFormat$ Index is {0}��.��51   G   Show53   #   54      �� 55      $��4��6%   
�������$��2q�6L   ._�56   &   ��   57   %   ��  ��  
StackPanel$ 2��$ DataContext���58   9   �� *deleteLogCommand+��59   )   �� $% (ItemsControl.AlternationIndex)� �� *TemplatedParent+$ Index is {0}��.��5;   G   Delete5=   '   5>   #   5@      � 5A       5B      �� 5C   "   $��* �63   �� 5D   "   $��1.25* �63   �� 5E   "   $��* �63   �� 5F   "   $��* �63   �� 5G   "   $��1.25* �63   �� 5H   "   $��* �63   .+�5L      �� $��0��6%   
�������$��2q�6L   ._�5M   "   �� ��6,   �� *durationString+5N      �� 5O      $��1��6%   
�������$��2q�6L   ._�5P   "   �� ��6,   �� *
distance+5Q      �� 5R      $��2��6%   
�������$��2q�6L   ._�5S   "   �� ��6,   �� *averageSpeedString+5T      �� 5U      $��3��6%   
�������$��2q�6L   ._�5V   "   �� ��6,   �� *topSpeedString+5W      �� 5X      $��4��6%   
�������$��2q�6L   ._�5Y   "   �� ��6,   �� *caloriesString+5Z      �� 5[      $��5��6%   
�������$��2q�6L   ._�5\   "   �� ��6,   �� *ratingString+5]      5^      �� 5_      
�������$��2q�68   ._�5`      �� ��6(   �� *report+5a      5b      5c      5d      5f      5g      5h      5i      