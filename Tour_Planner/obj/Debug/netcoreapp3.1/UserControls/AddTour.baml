   M S B A M L   `   `   `  ����?  ;View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Tour_Planner.View.UserControlsTour_Planner.View.UserControls  5      D @ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:ViewModel;assembly=ViewModel	ViewModel 5      ,    &Tour_Planner.View.UserControls.AddTour   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:Tour_Planner.View.UserControls     5      @	viewModel*clr-namespace:ViewModel;assembly=ViewModel     5      .��5      �� 
�������  � DataContext  6$   �� *addToursViewModel+.+�5   
   ��  �� TextAlignment$ Center=�6   
New Tour65   �� 5   
   .��6   Title:6   �� 5   
   -   5         ��Name$ NewTourTitle��5      $
��Auto��6C   ��6(   �� *	inputName+6C   �� 5   
   .��6   Description:6   �� 5   
   -   5        $ NewTourDescription��5      ��6.   �� *inputDescription+�� 5   
   .��6   Information:6   �� 5   
   -   5        $ NewTourInformation��5      ��6.   �� *inputInformation+�� 5   
   .��6   Starting Location:6$   �� 5   
   -   5        $ NewTourStart��5      ��6(   �� *inputStartLocation+�� 5   
   .��6   Ending Location:6"   �� 5   
   -   5        $ 
NewTourEnd��5      ��6&   �� *inputEndLocation+�� 5   
   ��6   �� *SearchAddressCommand+.��6:   Search6B   �� 5   
   ��6   �� *AddTourCommand+.��64   	Confirm6=   �� 5   
   .��6   Input Location:6!   �� 5   
   -   5        $ importLocation��5      ��6*   �� *	inputPath+�� 5   
   ��6   �� *importTourCommand+.��67   Import File6D   5      5       