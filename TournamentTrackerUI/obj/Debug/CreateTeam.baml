   M S B A M L   `   `   `  ����N  JTournamentTrackerUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TournamentTrackerUITournamentTrackerUI  5   	   $    TournamentTrackerUI.CreateTeam   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:TournamentTrackerUI     5   	     � Title$  Create Team��5   	   $��597.2��6   $��513.6��6,   .��5	      � $��
0,0,-0.4,0q�6   .+�5
   
   �� $��Create Team��6    J� RenderTransformOrigin$ 0.477,0.485&�6&   $��25(�6J   $��	28,28,0,0q�6X   $
��Left=�6k   $	��242��6�   $��58��6�   $	��Top=�6�   �� 5   
   $��	Team name��6   $��	42,86,0,0q�6$   $
��Left=�67   $	��166��6R   $��37��6^   $	��Top=�6j   �� 5   
   -   5        $��textBox_team_name��5      $
��Left=�6+   $��23��6F   $��
42,123,0,0q�6R    �� TextWrapping$
 Wrap=�6f   $��textBox_team_name��6z   $	��Top=�6�   $	��196��6�   �� 5   
   $��Select team Member��6   $��
41,153,0,0q�6-   $
��Left=�6A   $	��121��6\   $��28��6h   $	��Top=�6t   �� 5   
   -   5        $#��comboBox_team_member_selector��5      $
��Left=�68   $��
42,181,0,0q�6S   $	��Top=�6g   $	��196��6   �� 5   
   $��Add new member��6   $
��Left=�6+   $	��215��6F   $��
41,257,0,0q�6S   $	��Top=�6g   $	��197��6   �� 5   
   $��
First name��6   $��
46,283,0,0q�6%   $
��Left=�69   $��69��6T   $��33��6_   $	��Top=�6k   �� 5   
   -   5        $��	firstName��5      $
��Left=�6#   $��23��6>   $��115,287,0,0q�6J   $
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��107��6�   �� 5   
   $��	Last name��6   $��
46,311,0,0q�6$   $
��Left=�68   $��69��6S   $��33��6^   $	��Top=�6j   �� 5   
   -   5        $��lastName��5      $
��Left=�6"   $��23��6=   $��115,315,0,0q�6I   $
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��107��6�   �� 5   
   $��Email��6   $��46,339,0,112q�6    $
��Left=�66   $��69��6Q   �� 5   
   -   5        $��email��5      $
��Left=�6   $��23��6:   $��115,343,0,0q�6F   $
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $	��107��6�   �� 5   
   $��	Telephone��6   $��
46,366,0,0q�6$   $
��Left=�68   $��69��6S   $��33��6^   $	��Top=�6j   �� 5   
   -   5        $��	telephone��5      $
��Left=�6#   $��23��6>   $��115,370,0,0q�6J   $
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��107��6�   �� 5   
   -   5        $��button_addMember��5      $��
Add member��6)   $
��Left=�6>   $��
80,212,0,0q�6Y   $	��Top=�6m   $	��104��6�   $��40��6�   6�   �� 5   
   -   5        $��button_createMember��5      $��Create member��6,   $
��Left=�6D   $��
80,414,0,0q�6_   $	��Top=�6s   $	��104��6�   $��40��6�   6�   �� 5   
   -	   5        $"��listBox_selected_team_member��5      $
��Left=�66   $	��276��6Q   $��276,123,0,0q�6^   $	��Top=�6s   $	��198��6�   �� 5   
   -
   5        $��button_removeSelected��5      $��Remove selected��6.   $
��Left=�6H   $��323,414,0,0q�6c   $	��Top=�6x   $	��103��6�   $��40��6�   6�   �� 5   
   -   5        $��button_createTeam��5      $��Create Team��6*   $
��Left=�6@   $��206,501,0,0q�6[   $	��Top=�6p   $	��104��6�   $��40��6�   6�   5      5      