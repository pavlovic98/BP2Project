   M S B A M L   `   `   `  ����H  DBaze projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Baze_projekatBaze_projekat  5   	   9!clr-namespace:Baze_projekat.ViewsBaze_projekat.Views  5   	   C&clr-namespace:Baze_projekat.ViewModelsBaze_projekat.ViewModels  5   	       Baze_projekat.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Baze_projekat     5   	   3views!clr-namespace:Baze_projekat.Views     5   	   =
viewModels&clr-namespace:Baze_projekat.ViewModels     5   	     � Title$  Basketball clubs��5
   	   $	��650��6"   $	��890��6/    � WindowStartupLocation$ CenterScreen=�6;    � Icon$ Images/basket.png��6`    � 	Resources 5       �� DataType-   'Baze_projekat.ViewModels.ClubsViewModel#   Baze_projekat.Views.CLubsView/   )Baze_projekat.ViewModels.PlayersViewModel%   Baze_projekat.Views.PlayersView1   +Baze_projekat.ViewModels.PositionsViewModel&    Baze_projekat.Views.PositionView8  2Baze_projekat.ViewModels.PlayersPositionsViewModel.   (Baze_projekat.Views.PlayersPositionsView.	   (Baze_projekat.ViewModels.LeagueViewModel$
   Baze_projekat.Views.LeagueView/   )Baze_projekat.ViewModels.LicenseViewModel%   Baze_projekat.Views.LicenseView2   ,Baze_projekat.ViewModels.ClubLeagueViewModel(   "Baze_projekat.Views.ClubLeagueView0   *Baze_projekat.ViewModels.FacilityViewModel&    Baze_projekat.Views.FacilityView.   (Baze_projekat.ViewModels.MatchsVIewModel$   Baze_projekat.Views.MatchsVIew1   +Baze_projekat.ViewModels.EmployeesVIewModel'   !Baze_projekat.Views.EmployeesView4   .Baze_projekat.ViewModels.PlayerCentarViewModel*   $Baze_projekat.Views.PlayerCentarView��%9  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *, +)(�� �     5      *,	 +)(�� �     5      *, +)(�� ,    5      *, +)(�� ^    5!      *, +)(�� �    5$      *, +)(�� �    5'      *, +)(�� �    5*      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   " 	 6   .R�5      
  5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5       �� 5!   
   "  6   .R�5"        5#      �� 5$   
   "  6   .R�5%        5&      �� 5'   
   "  6   .R�5(        5)      �� 5*   
   "  6   .R�5+        5,      5-      ��5.      �� 5/   
   .��50      �  � Color$	 red��6    � Offset$	 0.2Q�6'   � 51      $
 Blue��6   $	 0.5Q�6(   � 52      $ White��6   $	 0.8Q�6)   53      .��55      �� .+�56   
   ]�  �� Left$ 0��6   .+�57      o� $	��Top=�6   $
��auto��6(   $��Center=�66   $��Center=�6S   $��2q�6w   .@�59      m� $��Clubs��6    m� CommandParameter$ clubs��6I   $��35��6b   $��12(�6n   $��10q�6|   
������ $
��Bold"�6�   	 m� Command	 6*   �� *
NavCommand+6�   m� 5:      $��Players��6   $��35��6K   $��12(�6W   $��10q�6e   
������ $
��Bold"�6�   $ players��5;      	 5:   ,   �� *
NavCommand+5;      m� 5<      $��	Pozitions��6   $��35��6M   $��12(�6Y   $��10q�6g   
������ $
��Bold"�6�   $ 	positions��5=      	 5<   .   �� *
NavCommand+5=      m� 5>      $��Players on positions��6   $��35��6X   $��12(�6d   $��10q�6r   
������ $
��Bold"�6�   $ playerposition��5?      	 5>   9   �� *
NavCommand+5?      m� 5@      $��Leagues��6   $��35��6K   $��12(�6W   $��10q�6e   
������ $
��Bold"�6�   $ leagues��5A      	 5@   ,   �� *
NavCommand+5A      m� 5B      $��Licenses��6   $��35��6L   $��12(�6X   $��10q�6f   
������ $
��Bold"�6�   $ licenses��5C      	 5B   -   �� *
NavCommand+5C      m� 5D      $��Clubs in leagues��6   $��35��6T   $��12(�6`   $��10q�6n   
������ $
��Bold"�6�   $ clubleagues��5E      	 5D   5   �� *
NavCommand+5E      m� 5F      $��
Facilities��6   $��35��6N   $��12(�6Z   $��10q�6h   
������ $
��Bold"�6�   $ 
facilities��5G      	 5F   /   �� *
NavCommand+5G      m� 5H      $��Matches��6   $��35��6K   $��12(�6W   $��10q�6e   
������ $
��Bold"�6�   $ matches��5I      	 5H   ,   �� *
NavCommand+5I      m� 5J      $��	Employees��6   $��35��6M   $��12(�6Y   $��10q�6g   
������ $
��Bold"�6�   $ 	employees��5K      	 5J   .   �� *
NavCommand+5K      m� 5L      $��	Treatment��6   $��35��6M   $��12(�6Y   $��10q�6g   
������ $
��Bold"�6�   $ pc��5M      	 5L   .   �� *
NavCommand+5M      5N      5O      �� 5P   
   

 �� Top$
 70��6   $	��800��6!   $	��550��6-   .+�5Q      �� $
 auto��6    �� Right$
 auto��60   ��6D   �� *CurrentViewModel+5R      5U      5V      