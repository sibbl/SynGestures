object Form1: TForm1
  Left = 0
  Top = 0
  BorderIcons = [biSystemMenu, biMinimize]
  BorderStyle = bsSingle
  Caption = 'SynGestures - Settings'
  ClientHeight = 340
  ClientWidth = 369
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  Icon.Data = {
    0000010001001010000001002000680400001600000028000000100000002000
    0000010020000000000040040000000000000000000000000000000000000000
    000000000000000000000000000000000000000000005C5C5CFF5C5C5CFF5C5C
    5CFF5C5C5CFF5C5C5CFF5C5C5CFF5C5C5CFF0000000000000000000000000000
    00000000000000000000000000000000000000000000616161FFEDEDEDFFEDED
    EDFFEDEDEDFFEDEDEDFFEDEDEDFF616161FF0000000000000000000000000000
    00000000000000000000000000000000000000000000616161FFEDEDEDFFEDED
    EDFFEDEDEDFFEDEDEDFFEDEDEDFF616161FF0000000000000000000000000000
    0000000000000000000000000000000000006C6C6CFFF1F1F1FFEDEDEDFFEDED
    EDFFEDEDEDFFEDEDEDFFF1F1F1FFF1F1F1FF6C6C6CFF00000000000000000000
    0000000000000000000000000000737373FFF1F1F1FFF1F1F1FFF1F1F1FFF1F1
    F1FFF1F1F1FFF1F1F1FFF1F1F1FFF1F1F1FF737373FF00000000000000000000
    00000000000000000000797979FFF1F1F1FFF1F1F1FFF1F1F1FFF1F1F1FFF1F1
    F1FFF1F1F1FFF1F1F1FFF1F1F1FFF1F1F1FF797979FF00000000000000000000
    000000000000818181FFF1F1F1FFF1F1F1FF818181FFF1F1F1FFF1F1F1FFF1F1
    F1FFF1F1F1FFF1F1F1FFF1F1F1FFF1F1F1FF818181FF00000000000000000000
    000000000000888888FFF1F1F1FF888888FF888888FFF9F9F9FFF1F1F1FFF9F9
    F9FFF1F1F1FFF9F9F9FFF1F1F1FFF9F9F9FF888888FF00000000000000000000
    000000000000000000008F8F8FFF000000008F8F8FFFF9F9F9FFF9F9F9FFF9F9
    F9FFF9F9F9FFF9F9F9FFF9F9F9FFF1F1F1FF8F8F8FFF00000000000000000000
    000000000000000000000000000000000000979797FFF9F9F9FF8F8F8FFFF9F9
    F9FF979797FFF9F9F9FF979797FFF9F9F9FF979797FF00000000000000000000
    000000000000000000000000000000000000979797FFF9F9F9FFA4A4A4FFF9F9
    F9FF979797FFA4A4A4FF979797FFA4A4A4FF0000000000000000000000000000
    000000000000000000000000000000000000A4A4A4FFF9F9F9FFAAAAAAFFF9F9
    F9FFAAAAAAFF0000000000000000000000000000000000000000000000000000
    000000000000000000000000000000000000AAAAAAFFF9F9F9FFAAAAAAFFF9F9
    F9FFAAAAAAFF0000000000000000000000000000000000000000000000000000
    000000000000000000000000000000000000AFAFAFFFF9F9F9FFAFAFAFFFF9F9
    F9FFAFAFAFFF0000000000000000000000000000000000000000000000000000
    00000000000000000000000000000000000000000000B4B4B4FFB4B4B4FFF9F9
    F9FFB4B4B4FF0000000000000000000000000000000000000000000000000000
    000000000000000000000000000000000000000000000000000000000000B4B4
    B4FF00000000000000000000000000000000000000000000000000000000FC07
    0000FC070000FC070000F8030000F0030000E0030000C0030000C0030000E803
    0000F8030000F8070000F83F0000F83F0000F83F0000FC3F0000FF7F0000}
  OldCreateOrder = False
  Position = poScreenCenter
  OnClose = FormClose
  PixelsPerInch = 96
  TextHeight = 13
  object Label6: TLabel
    Left = 31
    Top = 84
    Width = 22
    Height = 13
    Caption = 'Top:'
  end
  object Label8: TLabel
    Left = 216
    Top = 64
    Width = 129
    Height = 13
    Caption = 'For more options you need'
  end
  object ok: TButton
    Left = 205
    Top = 303
    Width = 75
    Height = 25
    Caption = 'OK'
    Default = True
    ModalResult = 1
    TabOrder = 0
    OnClick = okClick
  end
  object cancel: TButton
    Left = 286
    Top = 303
    Width = 75
    Height = 25
    Cancel = True
    Caption = 'Cancel'
    ModalResult = 2
    TabOrder = 1
    OnClick = cancelClick
  end
  object defaults: TButton
    Left = 8
    Top = 303
    Width = 75
    Height = 25
    Caption = 'Defaults'
    TabOrder = 2
    OnClick = defaultsClick
  end
  object pages: TPageControl
    Left = 8
    Top = 8
    Width = 353
    Height = 289
    ActivePage = scrollTab
    TabOrder = 3
    object generalTab: TTabSheet
      Caption = 'General'
      ImageIndex = 2
      object GroupBox4: TGroupBox
        Left = 3
        Top = 3
        Width = 334
        Height = 255
        Caption = 'Settings'
        TabOrder = 0
        object startWithWindows: TCheckBox
          Left = 21
          Top = 29
          Width = 113
          Height = 17
          Caption = 'Start with Windows'
          TabOrder = 0
        end
      end
    end
    object scrollTab: TTabSheet
      Caption = 'Scrolling'
      object GroupBox2: TGroupBox
        Left = 3
        Top = 120
        Width = 334
        Height = 76
        Caption = 'Sensitivity'
        TabOrder = 2
        object scrollSpeedLabel: TLabel
          Left = 16
          Top = 20
          Width = 30
          Height = 13
          Caption = 'Speed'
        end
        object scrollAcc: TTrackBar
          Left = 175
          Top = 39
          Width = 141
          Height = 34
          Enabled = False
          Max = 120
          Min = 30
          Frequency = 6
          Position = 40
          TabOrder = 1
        end
        object scrollAccEnabled: TCheckBox
          Left = 187
          Top = 18
          Width = 79
          Height = 17
          Caption = 'Acceleration'
          TabOrder = 2
          OnClick = scrollAccEnabledClick
        end
        object scrollSpeed: TTrackBar
          Left = 16
          Top = 39
          Width = 145
          Height = 34
          Max = 110
          Min = 10
          Frequency = 10
          Position = 10
          TabOrder = 0
        end
      end
      object GroupBox8: TGroupBox
        Left = 3
        Top = 63
        Width = 334
        Height = 54
        Caption = 'Vertical scroll'
        TabOrder = 1
        object scrollLinearEdgeY: TCheckBox
          Left = 187
          Top = 22
          Width = 129
          Height = 17
          Caption = 'Keep scrolling on edges'
          Checked = True
          State = cbChecked
          TabOrder = 2
        end
        object scrollOffY: TRadioButton
          Left = 62
          Top = 22
          Width = 33
          Height = 17
          Caption = 'Off'
          TabOrder = 1
          TabStop = True
          OnClick = scrollLinearYClick
        end
        object scrollLinearY: TRadioButton
          Left = 21
          Top = 22
          Width = 35
          Height = 17
          Caption = 'On'
          Checked = True
          TabOrder = 0
          TabStop = True
          OnClick = scrollLinearYClick
        end
      end
      object GroupBox1: TGroupBox
        Left = 3
        Top = 3
        Width = 334
        Height = 57
        Caption = 'Horizontal scroll'
        TabOrder = 0
        object scrollLinearEdgeX: TCheckBox
          Left = 187
          Top = 24
          Width = 129
          Height = 17
          Caption = 'Keep scrolling on edges'
          Checked = True
          State = cbChecked
          TabOrder = 2
        end
        object scrollLinearX: TRadioButton
          Left = 21
          Top = 24
          Width = 35
          Height = 17
          Caption = 'On'
          Checked = True
          TabOrder = 0
          TabStop = True
          OnClick = scrollLinearXClick
        end
        object scrollOffX: TRadioButton
          Left = 62
          Top = 24
          Width = 33
          Height = 17
          Caption = 'Off'
          TabOrder = 1
          OnClick = scrollLinearXClick
        end
      end
      object GroupBox3: TGroupBox
        Left = 3
        Top = 199
        Width = 334
        Height = 58
        Caption = 'Scroll mode'
        TabOrder = 3
        object scrollCompatible: TRadioButton
          Left = 86
          Top = 24
          Width = 73
          Height = 17
          Caption = 'Compatible'
          TabOrder = 1
        end
        object scrollSmooth: TRadioButton
          Left = 21
          Top = 24
          Width = 57
          Height = 17
          Caption = 'Smooth'
          Checked = True
          TabOrder = 0
          TabStop = True
        end
        object scrollReverse: TCheckBox
          Left = 187
          Top = 22
          Width = 129
          Height = 17
          Caption = 'Reverse scrolling'
          TabOrder = 2
        end
      end
    end
    object tapTab: TTabSheet
      Caption = 'Tapping'
      ImageIndex = 1
      object GroupBox5: TGroupBox
        Left = 3
        Top = 2
        Width = 334
        Height = 250
        Caption = 'Settings'
        TabOrder = 0
        object tapMaxDistanceLabel: TLabel
          Left = 16
          Top = 144
          Width = 165
          Height = 13
          Caption = 'Maximal finger movement distance'
        end
        object Label2: TLabel
          Left = 16
          Top = 24
          Width = 83
          Height = 13
          Caption = 'One + one finger'
        end
        object Label3: TLabel
          Left = 176
          Top = 83
          Width = 64
          Height = 13
          Caption = 'Three fingers'
        end
        object Label4: TLabel
          Left = 176
          Top = 24
          Width = 56
          Height = 13
          Caption = 'Two fingers'
        end
        object Label5: TLabel
          Left = 16
          Top = 83
          Width = 83
          Height = 13
          Caption = 'Two + one finger'
        end
        object tapMaxDistance: TTrackBar
          Left = 16
          Top = 163
          Width = 305
          Height = 38
          Max = 100
          Min = 5
          Frequency = 5
          Position = 5
          TabOrder = 4
        end
        object tapOneOne: TComboBox
          Left = 16
          Top = 43
          Width = 145
          Height = 19
          Style = csOwnerDrawFixed
          ItemHeight = 13
          ItemIndex = 0
          TabOrder = 0
          Text = 'Disabled'
          Items.Strings = (
            'Disabled'
            'Left button'
            'Middle button'
            'Right button'
            'Button 4'
            'Button 5')
        end
        object tapThree: TComboBox
          Left = 176
          Top = 102
          Width = 145
          Height = 19
          Style = csOwnerDrawFixed
          ItemHeight = 13
          ItemIndex = 0
          TabOrder = 3
          Text = 'Disabled'
          Items.Strings = (
            'Disabled'
            'Left button'
            'Middle button'
            'Right button'
            'Button 4'
            'Button 5')
        end
        object tapTwo: TComboBox
          Left = 176
          Top = 43
          Width = 145
          Height = 19
          Style = csOwnerDrawFixed
          ItemHeight = 13
          ItemIndex = 0
          TabOrder = 1
          Text = 'Disabled'
          Items.Strings = (
            'Disabled'
            'Left button'
            'Middle button'
            'Right button'
            'Button 4'
            'Button 5')
        end
        object tapTwoOne: TComboBox
          Left = 16
          Top = 102
          Width = 145
          Height = 19
          Style = csOwnerDrawFixed
          ItemHeight = 13
          ItemIndex = 0
          TabOrder = 2
          Text = 'Disabled'
          Items.Strings = (
            'Disabled'
            'Left button'
            'Middle button'
            'Right button'
            'Button 4'
            'Button 5')
        end
      end
    end
    object swipeTab: TTabSheet
      Caption = 'Swipes'
      ImageIndex = 3
      object GroupBox6: TGroupBox
        Left = 3
        Top = 3
        Width = 334
        Height = 94
        Caption = 'Two finger swipes'
        TabOrder = 0
        object Label1: TLabel
          Left = 16
          Top = 24
          Width = 23
          Height = 13
          Caption = 'Left:'
        end
        object Label7: TLabel
          Left = 16
          Top = 49
          Width = 29
          Height = 13
          Caption = 'Right:'
        end
        object lblHintScrolling: TLabel
          Left = 16
          Top = 72
          Width = 291
          Height = 13
          Caption = 'For more options you need to deactivate horizontal scrolling!'
          Visible = False
          WordWrap = True
        end
        object swipeTwoLeft: TComboBox
          Left = 55
          Top = 21
          Width = 272
          Height = 19
          Style = csOwnerDrawFixed
          ItemHeight = 13
          TabOrder = 0
        end
        object swipeTwoRight: TComboBox
          Left = 55
          Top = 46
          Width = 272
          Height = 19
          Style = csOwnerDrawFixed
          ItemHeight = 13
          TabOrder = 1
        end
      end
      object GroupBox7: TGroupBox
        Left = 3
        Top = 103
        Width = 334
        Height = 155
        Caption = 'Three finger swipes'
        TabOrder = 1
        object Label9: TLabel
          Left = 16
          Top = 24
          Width = 17
          Height = 13
          Caption = 'Up:'
        end
        object Label10: TLabel
          Left = 16
          Top = 49
          Width = 31
          Height = 13
          Caption = 'Down:'
        end
        object Label11: TLabel
          Left = 17
          Top = 74
          Width = 23
          Height = 13
          Caption = 'Left:'
        end
        object Label12: TLabel
          Left = 17
          Top = 99
          Width = 25
          Height = 13
          Caption = 'Right'
        end
        object swipeThreeTop: TComboBox
          Left = 55
          Top = 21
          Width = 272
          Height = 19
          Style = csOwnerDrawFixed
          ItemHeight = 13
          TabOrder = 0
        end
        object swipeThreeBottom: TComboBox
          Left = 55
          Top = 46
          Width = 272
          Height = 19
          Style = csOwnerDrawFixed
          ItemHeight = 13
          TabOrder = 1
        end
        object swipeThreeRight: TComboBox
          Left = 55
          Top = 96
          Width = 272
          Height = 19
          Style = csOwnerDrawFixed
          ItemHeight = 13
          TabOrder = 2
        end
        object swipeThreeLeft: TComboBox
          Left = 55
          Top = 71
          Width = 272
          Height = 19
          Style = csOwnerDrawFixed
          ItemHeight = 13
          TabOrder = 3
        end
      end
    end
  end
  object PopupMenu1: TPopupMenu
    Left = 104
    Top = 312
    object Settings1: TMenuItem
      Caption = 'Settings'
      Default = True
      OnClick = Settings1Click
    end
    object globalActive: TMenuItem
      AutoCheck = True
      Caption = 'Enabled'
      Checked = True
    end
    object N1: TMenuItem
      Caption = '-'
    end
    object About1: TMenuItem
      Caption = 'About'
      OnClick = About1Click
    end
    object Exit1: TMenuItem
      Caption = 'Exit'
      OnClick = Exit1Click
    end
  end
  object reactivateTimer: TTimer
    Enabled = False
    Interval = 500
    OnTimer = reactivateTimerTimer
    Left = 128
    Top = 312
  end
  object TrayIcon1: TTrayIcon
    Icon.Data = {
      0000010001001010000001002000680400001600000028000000100000002000
      0000010020000000000040040000000000000000000000000000000000000000
      000000000000000000000000000000000000000000005C5C5CFF5C5C5CFF5C5C
      5CFF5C5C5CFF5C5C5CFF5C5C5CFF5C5C5CFF0000000000000000000000000000
      00000000000000000000000000000000000000000000616161FFEDEDEDFFEDED
      EDFFEDEDEDFFEDEDEDFFEDEDEDFF616161FF0000000000000000000000000000
      00000000000000000000000000000000000000000000616161FFEDEDEDFFEDED
      EDFFEDEDEDFFEDEDEDFFEDEDEDFF616161FF0000000000000000000000000000
      0000000000000000000000000000000000006C6C6CFFF1F1F1FFEDEDEDFFEDED
      EDFFEDEDEDFFEDEDEDFFF1F1F1FFF1F1F1FF6C6C6CFF00000000000000000000
      0000000000000000000000000000737373FFF1F1F1FFF1F1F1FFF1F1F1FFF1F1
      F1FFF1F1F1FFF1F1F1FFF1F1F1FFF1F1F1FF737373FF00000000000000000000
      00000000000000000000797979FFF1F1F1FFF1F1F1FFF1F1F1FFF1F1F1FFF1F1
      F1FFF1F1F1FFF1F1F1FFF1F1F1FFF1F1F1FF797979FF00000000000000000000
      000000000000818181FFF1F1F1FFF1F1F1FF818181FFF1F1F1FFF1F1F1FFF1F1
      F1FFF1F1F1FFF1F1F1FFF1F1F1FFF1F1F1FF818181FF00000000000000000000
      000000000000888888FFF1F1F1FF888888FF888888FFF9F9F9FFF1F1F1FFF9F9
      F9FFF1F1F1FFF9F9F9FFF1F1F1FFF9F9F9FF888888FF00000000000000000000
      000000000000000000008F8F8FFF000000008F8F8FFFF9F9F9FFF9F9F9FFF9F9
      F9FFF9F9F9FFF9F9F9FFF9F9F9FFF1F1F1FF8F8F8FFF00000000000000000000
      000000000000000000000000000000000000979797FFF9F9F9FF8F8F8FFFF9F9
      F9FF979797FFF9F9F9FF979797FFF9F9F9FF979797FF00000000000000000000
      000000000000000000000000000000000000979797FFF9F9F9FFA4A4A4FFF9F9
      F9FF979797FFA4A4A4FF979797FFA4A4A4FF0000000000000000000000000000
      000000000000000000000000000000000000A4A4A4FFF9F9F9FFAAAAAAFFF9F9
      F9FFAAAAAAFF0000000000000000000000000000000000000000000000000000
      000000000000000000000000000000000000AAAAAAFFF9F9F9FFAAAAAAFFF9F9
      F9FFAAAAAAFF0000000000000000000000000000000000000000000000000000
      000000000000000000000000000000000000AFAFAFFFF9F9F9FFAFAFAFFFF9F9
      F9FFAFAFAFFF0000000000000000000000000000000000000000000000000000
      00000000000000000000000000000000000000000000B4B4B4FFB4B4B4FFF9F9
      F9FFB4B4B4FF0000000000000000000000000000000000000000000000000000
      000000000000000000000000000000000000000000000000000000000000B4B4
      B4FF00000000000000000000000000000000000000000000000000000000FC07
      0000FC070000FC070000F8030000F0030000E0030000C0030000C0030000E803
      0000F8030000F8070000F83F0000F83F0000F83F0000FC3F0000FF7F0000}
    PopupMenu = PopupMenu1
    Visible = True
    OnDblClick = Settings1Click
    Left = 80
    Top = 312
  end
end
