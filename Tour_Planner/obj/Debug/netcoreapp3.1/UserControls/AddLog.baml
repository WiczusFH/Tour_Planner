   M S B A M L   `   `   `  ����?  ;View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Tour_Planner.View.UserControlsTour_Planner.View.UserControls  5      D @ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:ViewModel;assembly=ViewModel	ViewModel 5      +    %Tour_Planner.View.UserControls.AddLog   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:Tour_Planner.View.UserControls     5      @	viewModel*clr-namespace:ViewModel;assembly=ViewModel     5      .��5      �� 
�������  � DataContext  6$   �� *addLogsViewModel+.+�5   
   ��  �� TextAlignment$ Center=�6   	New Log64   �� 5   
   .��6   
Log Title:6   �� 5   
   -   5         ��Name$ NewLogTitle��5      $
��Auto��6F   ��6'   �� *inputLogTitle+6F   �� 5   
   .��6   Route Name:6   �� 5   
   $
��Auto��6    �� DisplayMemberPath$
 name��6A    �� SelectedValuePath$
 name��5      ��5       �� *
tourList+ �� SelectedValue 5      �� *inputRouteName+5      �� 5   
   .��6   Date:6   �� 5   
   -   5        $ 
NewLogDate��5      $
��Auto��6A   ��6&   �� *	inputDate+6A   �� 5   
   .��6   	Duration:6   �� 5   
   -   5        $ NewLogDuration��5      $
��Auto��6I   ��6*   �� *inputDuration+6I   �� 5   
   .��6   
Top Speed:6   �� 5   
   -   5        $ TopSpeed��5      $
��Auto��6>   ��6$   �� *
topSpeed+6>   �� 5   
   .��6   	Report:6   �� 5   
   -   5        $ Report��5      $
��Auto��6:   ��6"   �� *report+6:   �� 5   
   .��6   	Rating:6   �� 5    
   -   5        $ Rating��5       $
��Auto��6:   ��6"   �� *rating+6:   �� 5!   
   ��6   �� *addLogCommand+.��63   	Confirm6<   5"      5#      