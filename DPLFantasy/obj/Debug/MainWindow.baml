   M S B A M L   `   `   `  ����E  ADPLFantasy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:DPLFantasy
DPLFantasy  5   	       DPLFantasy.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:DPLFantasy     5   	     � Title$  
MainWindow��5   	   $��671.6��6   $
��1199��6+   .��5
      � $��0,83,-34.2,-197q�6    � ColumnDefinitions 5   
   �� 5      $	��75* �6   �� 5      $
��243* �6   �� 5      $
��487* �6   �� 5      �� 5      $
��421* �6   .+�5   
   �� -   5         ��Name$ 
tabControl��5      $
��Left=�6)   $	��639��6D   $��
10,-77,0,0q�6Q   $	��Top=�6e   $
��1179��6}   $��5��6�   .@�5      �� $��	Make Team��6   .��5      � $��8,53,-23.8,-10.8q�6   .+�5      � ���	#FFE5E5E5$��-10,-15,-112,-31q�62   $
��Left=�6L   $
��1181��6g    � RowDefinitions 5      �� 5      $
��559* �6,   �� 5      $	��44* �6,   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ dgFirstTeam��5         AutoGenerateColumns .     
IsReadOnly . $��Disabled=�6�   $��Disabled=�6+  $
��Bold"�6a  $
��Left=�6s  $��	36,52,0,0q�6�  $	��Top=�6�  $	��230��6�  $	��194��6�  ��64   �� *FirstDataGridView+ �� SelectedItem 6^   �� *SelectedPlayer+ �� Mode$ TwoWay=�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Name��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ 3* 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Name+6X     5      $
 Value��61   $ * 6[    6@   �� *Points+6[   5!      �� 5"      -   5         ��Name$ cbFirstTeam��5"       �� 
IsReadOnly .   �� 
IsEditable .  �� IsTextSearchEnabled . $
��Left=�6�   $��	36,25,0,0q�6�   $	��Top=�6�   $	��194��6�    J� RenderTransformOrigin$ 0.854,0.365&�6�   $��27��6    5$      -   5        $ dgSecondTeam��5$       .   . $��Disabled=�6�   $��Disabled=�6,  $
��Bold"�6b  $
��Left=�6t  $��
726,52,0,0q�6�  $	��Top=�6�  $	��230��6�  $	��194��6�   65   �� *SelectedPlayer+$ TwoWay=���6j   �� *SecondDataGridView+	 5%        5&      $

 Name��61   $ 3* 6X    6?   �� *Name+6X     5'      $
 Value��61   $ * 6[    6@   �� *Points+6[   5)      �� 5*      -   5        $ cbSecondTeam��5*       .   .  . $
��Left=�6�   $��
726,25,0,0q�6�   $	��Top=�6�   $	��194��6�   $ 0.854,0.365&�6�   $��27��6!    5,      -   5        $ dgThirdTeam��5,       .   . $��Disabled=�6�   $��Disabled=�6+  $
��Bold"�6a  $
��Left=�6s  $��
369,52,0,0q�6�  $	��Top=�6�  $	��230��6�  $	��194��6�   64   �� *SelectedPlayer+$ TwoWay=���6i   �� *ThirdDataGridView+	 5-        5.      $

 Name��61   $ 3* 6X    6?   �� *Name+6X     5/      $
 Value��61   $ * 6[    6@   �� *Points+6[   51      �� 52      -   5        $ cbThirdTeam��52       .   .  . $
��Left=�6�   $��
369,25,0,0q�6�   $	��Top=�6�   $	��194��6�   $ 0.854,0.365&�6�   $��27��6    54      -   5        $ dgDreamTeam��54       .   . $��Disabled=�6�   $��Disabled=�63  $
��Bold"�6i  $
��Left=�6{  $��369,320,0,0q�6�  $	��Top=�6�  $	��230��6�  $	��194��6�   65   �� *SelectedPlayer+$ TwoWay=���6j   �� *DreamDataGridView+	 55        56      $

 Name��61   $ 3* 6X    6?   �� *Name+6X     57      $
 Value��61   $ * 6[    6@   �� *Points+6[   59      �� 5:      -	   5         ��Name$ txtDreamTeam��5:      
�������{�. $
��Left=�6^   $��369,-46,0,0q�6y    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��194��6�   $��24��6�   �� 5;      -
   5         ��Name$ labelEnterDream��5;      $��Your Dream Team Name��65   $��DemiBold"�6T   $
��Left=�6j   $	��Top=�6�   $��
36,-46,0,0q�6�   $	��194��6�   �� 5<      -   5        $ labelDreamTeamName��5<      $��DemiBold"�6�   $
��Left=�6�   $	��Top=�6�   $��369,290,0,0q�6�   $	��194��6�   $ 2.331,-1.625&�6�   ��68   �� *Text+ �� ElementName$ txtDreamTeam�� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5=      -   5        $ labelTotalPoints��5=      $��Total Points��66   $
��Bold"�6M   $
��Left=�6`   $	��Top=�6{   $ 14.943,9.75&�6�   $��588,436,0,0q�6�   $��72��6�   $��32��6�   �� 5>      -   5        $ txtTotalPoints��5>       �� 
IsReadOnly . $
��Left=�6e   $��32��6�   $��588,468,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $��92��6�   ��66   �� *TotalPoints+6�   �� 5@      -   5        $ labelTotalSelectedPlayers��5@      $��Number Of Players��6?   $
��Bold"�6[   $
��Left=�6n   $	��Top=�6�   $ 14.943,9.75&�6�   $��807,436,0,0q�6�   $	��124��6�   $��32��6�   �� 5A      -   5        $ txtTotalSelectedPlayers��5A       . $
��Left=�6w   $��32��6�   $��816,468,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $��92��6�   ��6?   �� *TotalSelectedPlayers+6�   �� 5D      -   5         ��Name$ button��5D      $��Heavy"�6-   $��Submit��6@   $
��Left=�6n   $��728,524,0,0q�6�   $	��Top=�6�   $	��105��6�   $��26��6�   �� 5E      -   5        $ labelCaptain��5E      $��Heavy"�62   $��Captain Name��6E   $
��Left=�6\   $��588,320,0,0q�6w   $	��Top=�6�   $	��102��6�   �� 5F      -   5        $ labelViseCaptain��5F      $��Heavy"�66   $��Vise Captain Name��6I   $
��Left=�6e   $��588,392,0,0q�6�   $	��Top=�6�   $	��117��6�   �� 5G      -   5        $ cbCaptainName��5G       .   .  . $
��Left=�6�   $��726,319,0,0q�6�   $	��Top=�6�   $	��194��6�   $ 0.854,0.365&�6�   $��27��6  ��66   �� *DreamDataGridView+6  �� 5H      -   5        $ cbViseCaptainName��5H       .   .  . $
��Left=�6�   $��726,392,0,0q�6�   $	��Top=�6�   $	��194��6�   $ 0.854,0.365&�6�   $��27��6  ��6:   �� *DreamDataGridView+6  �� 5I      -   5        $ labelTodaysMatch��5I      $��Today's matches��66   $
��Bold"�6P   $
��Left=�6b   $��
406,-6,0,0q�6}   $	��Top=�6�   5J      5K      �� 5L      $��
Statistics��6   .��5M      � $��-1,14,0.6,-13.6q�6   .+�5N        -   5        $ dgTeamDataViewer��5N       .   . $��Disabled=�6�   $��Disabled=�6�   $
��Bold"�6  $
��Left=�6  $��1,63,0,0q�60  $	��Top=�6B  $	��222��6Z  $
��1162��6g  ��69   �� *DreamTeamPlayersDataView+	 5O        5P      $

 Name��61   $ * 6X    6?   �� *Name+6X     5Q      $
 Value��61   $
 Auto 6[    6@   �� *Points+6[     5R      $
 FromTeam��61   $
 Auto 6_    6C   �� *	Team_id+6_     5S      $

 Runs��61   $
 Auto 6^    6?   �� *
runsScored+6^     5T      $
 Four(s)��61   $
 Auto 6`    6B   �� *	noOfFours+6`     5U      $
 Six(s)��61   $
 Auto 6_    6A   �� *	noOfSixes+6_     5V      $
 	Wicket(s)��61   $
 Auto 6d    6D   �� *noOfwickets+6d     5W      $
 MaidenOver(s)��61   $
 Auto 6g    6H   �� *
maidenOver+6g     5X      $
 Catches��61   $
 Auto 6b    6B   �� *noOfCatches+6b     5Y      $
 Stumping��61   $
 Auto 6`    6C   �� *
stumping+6`     5Z      $
 RunOut(Throw)��61   $
 Auto 6h    6H   �� *runoutThrow+6h     5[      $
 RunOut(Catch)��61   $
 Auto 6h    6H   �� *runoutCatch+6h     5\      $

 Duck��61   $
 Auto 6X    6?   �� *duck+6X     5]      $
 Bonus Points(Runs)��61   $
 Auto 6r    6M   �� *bonusOnRunsScore+6r     5^      $
 Bonus Points(Wickets)��61   $
 Auto 6s    6P   �� *bonusOnWickets+6s     5_      $
 Total Points��61   $
 Auto 6g    6G   �� *totalPoints+6g   5a      �� 5b      -   5        $ cbTeamNames��5b       �� SelectedIndex$ 0��6]    .   .   . $
��Left=�6�   $��
504,13,0,0q�6�   $	��Top=�6  $	��194��6+  $ 0.854,0.365&�67  $��27��6[  ��64   �� *DreamTeamsByDate+6[  �� 5c      -   5        $ 	labelDate��5c      $��Select Date��6/   $
��Bold"�6E   $
��Left=�6X   $��
4,13,0,563q�6s   $��74��6�   �� 5d      -   5        $ labelTeamName��5d      $��	Team Name��63   $
��Bold"�6G   $
��Left=�6Y   $��
419,13,0,0q�6t   $	��Top=�6�   $ -1.25,2.859&�6�   $��30��6�   $��86��6�   (  "System.Windows.Controls.DatePicker  5e      -   5          Name$ dpDreamTeamPlayerData��5e   !   $��88,10,831,564q�6@   6W   �� 5f      -   5        $ txtTotalScoredPoint��5f      $
 Wrap=�6;   $��0��6O    �� TextAlignment$ Center=�6X   $
��Bold"�6o   $��959,326,9,251q�6�   �� 5g      -   5        $ lableTotalScoredPoints��5g      $��Total Scored Points��6<   $
��Bold"�6Z   $
��Left=�6m   $��834,326,0,251q�6�   �� 5h      -   5        $
 info��5h      $����*Select Date and we will populate the Team Name for that date.
  By default drop down is sorted in descending order of amount of points they have��6*   $
��Left=�6�   $��	714,4,0,0q�6�   $	��Top=�6�   $ -0.563,-0.305&�6  $��52��6;  $	��453��6G  5i      5j      5k      5l      5m      