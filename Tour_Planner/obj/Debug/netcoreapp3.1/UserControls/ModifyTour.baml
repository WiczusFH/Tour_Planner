   M S B A M L   `   `   `  ����?  ;View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Tour_Planner.View.UserControlsTour_Planner.View.UserControls  5      D @ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:ViewModel;assembly=ViewModel	ViewModel 5      /    )Tour_Planner.View.UserControls.ModifyTour   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:Tour_Planner.View.UserControls     5      @	viewModel*clr-namespace:ViewModel;assembly=ViewModel     5      .��5      �� 
�������  � DataContext  6$   �� *modifyTourViewModel+.+�5   
   �� .��6   Route Name:6   �� 5   
   $
��Auto��6    �� DisplayMemberPath$
 name��6A    �� SelectedValuePath$
 name��5      ��5       �� *
tourList+ �� SelectedValue 5      �� *inputRouteName+5      �� 5   
   .��6   Description:6   �� 5   
   -   5         ��Name$ NewTourDescription��5      ��6.   �� *newDescription+ �� Mode$ TwoWay=��� 5   
   .��6   Information:6   �� 5   
   -   5        $ NewTourInformation��5      ��6.   �� *newInformation+$ TwoWay=��� 5   
   ��6   �� *modifyCommand+.��63   	Confirm6<   5      5      