using System;
using Microsoft.Maui;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace CardView;

public class CardView : ContentView
{
    private readonly Frame _outerFrame;
    private readonly Frame _innerFrame;
    private readonly PanGestureRecognizer _panGestureRecognizer = new();

    public CardView()
    {
        CardViewHorizontalOptionsProperty = BindableProperty.Create(
           propertyName: nameof(CardViewHorizontalOptions),
           returnType: typeof(LayoutOptions),
           declaringType: typeof(CardView),
           defaultValue: LayoutOptions.Start,
           propertyChanged: CardViewHorizontalOptionsChanged);

        CardViewContentProperty = BindableProperty.Create(
            propertyName: nameof(CardViewContent),
            returnType: typeof(View),
            declaringType: typeof(CardView),
            propertyChanged: CardViewContentChanged);

        CardViewOutlineColorThicknessProperty = BindableProperty.Create(
            propertyName: nameof(CardViewOutlineColorThickness),
            returnType: typeof(Thickness),
            declaringType: typeof(CardView),
            defaultValue: new Thickness(0),
            propertyChanged: CardViewOutlineColorThicknessChanged);

        CardViewHeightRequestProperty = BindableProperty.Create(
            propertyName: nameof(CardViewHeightRequest),
            returnType: typeof(double),
            declaringType: typeof(CardView),
            defaultValue: -1d,
            propertyChanged: CardViewHeightRequestChanged);

        CardViewOutlineColorThicknessProperty = BindableProperty.Create(
            propertyName: nameof(CardViewOutlineColorThickness),
            returnType: typeof(Thickness),
            declaringType: typeof(CardView),
            defaultValue: new Thickness(0),
            propertyChanged: CardViewOutlineColorThicknessChanged);

        CardViewInnerFrameOutlineColorProperty = BindableProperty.Create(
            propertyName: nameof(CardViewInnerFrameOutlineColor),
            declaringType: typeof(CardView),
            returnType: typeof(Color),
            defaultValue: Colors.Transparent,
            propertyChanged: CardViewInnerFrameOutlineColorChanged);

        CardViewOutlineColorProperty = BindableProperty.Create(
            propertyName: nameof(CardViewOutlineColor),
            declaringType: typeof(CardView),
            returnType: typeof(Color),
            defaultValue: Colors.Transparent,
            propertyChanged: CardViewOutlineColorChanged);

        CardViewInnerFrameOutlineColorThicknessProperty = BindableProperty.Create(
            propertyName: nameof(CardViewInnerFrameOutlineColorThickness),
            returnType: typeof(Thickness),
            declaringType: typeof(CardView),
            defaultValue: new Thickness(0),
            propertyChanged: CardViewInnerFrameOutlineColorThicknessChanged);

        CardViewHasShadowProperty = BindableProperty.Create(
            propertyName: nameof(CardViewHasShadow),
            returnType: typeof(bool),
            declaringType: typeof(CardView),
            defaultValue: false,
            propertyChanged: CardViewHasShadowChanged);
        IsSwipeToClearEnabledProperty = BindableProperty.Create(
            propertyName: nameof(IsSwipeToClearEnabled),
            returnType: typeof(bool),
            declaringType: typeof(CardView),
            defaultValue: false,
            propertyChanged: CardViewSwipeToClearPropertyChanged);

        _innerFrame = new Frame
        {
            Padding = CardViewInnerFrameOutlineColorThickness,
            HasShadow = false,
            BorderColor = Colors.Transparent,
            BackgroundColor = CardViewInnerFrameOutlineColor,
            HeightRequest = CardViewHeightRequest,
            HorizontalOptions = CardViewHorizontalOptions
        };

        _outerFrame = new Frame
        {
            Padding = CardViewOutlineColorThickness,
            HasShadow = CardViewHasShadow,
            BorderColor = Colors.Transparent,
            HeightRequest = CardViewHeightRequest,
            BackgroundColor = CardViewOutlineColor,
            Content = _innerFrame
        };

        Content = _outerFrame;
    }

    public readonly BindableProperty CardViewHorizontalOptionsProperty;

    public readonly BindableProperty CardViewContentProperty;

    public readonly BindableProperty CardViewHeightRequestProperty;

    public readonly BindableProperty CardViewOutlineColorProperty;

    public readonly BindableProperty CardViewInnerFrameOutlineColorProperty;

    public readonly BindableProperty CardViewOutlineColorThicknessProperty;

    public readonly BindableProperty CardViewInnerFrameOutlineColorThicknessProperty;

    public readonly BindableProperty CardViewHasShadowProperty;

    public readonly BindableProperty IsSwipeToClearEnabledProperty;

    public View CardViewContent
    {
        get => (View)GetValue(CardViewContentProperty);
        set => SetValue(CardViewContentProperty, value);
    }

    public LayoutOptions CardViewHorizontalOptions
    {
        get => (LayoutOptions)GetValue(CardViewHorizontalOptionsProperty);
        set => SetValue(CardViewHorizontalOptionsProperty, value);
    }

    public double CardViewHeightRequest
    {
        get => (double)GetValue(CardViewHeightRequestProperty);
        set => SetValue(CardViewHeightRequestProperty, value);
    }

    public Color CardViewOutlineColor
    {
        get => (Color)GetValue(CardViewOutlineColorProperty);
        set => SetValue(CardViewOutlineColorProperty, value);
    }

    public Color CardViewInnerFrameOutlineColor
    {
        get => (Color)GetValue(CardViewInnerFrameOutlineColorProperty);
        set => SetValue(CardViewInnerFrameOutlineColorProperty, value);
    }

    public Thickness CardViewOutlineColorThickness
    {
        get => (Thickness)GetValue(CardViewOutlineColorThicknessProperty);
        set => SetValue(CardViewOutlineColorThicknessProperty, value);
    }

    public Thickness CardViewInnerFrameOutlineColorThickness
    {
        get => (Thickness)GetValue(CardViewInnerFrameOutlineColorThicknessProperty);
        set => SetValue(CardViewInnerFrameOutlineColorThicknessProperty, value);
    }

    public bool CardViewHasShadow
    {
        get => (bool)GetValue(CardViewHasShadowProperty);
        set => SetValue(CardViewHasShadowProperty, value);
    }

    public bool IsSwipeToClearEnabled
    {
        get => (bool)GetValue(IsSwipeToClearEnabledProperty);
        set => SetValue(IsSwipeToClearEnabledProperty, value);
    }

    private static void CardViewContentChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        CompareOldAndNewValue(oldvalue, newvalue, () => ((CardView)bindable).ChangeCardViewContent());
    }

    private static void CardViewHeightRequestChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        CompareOldAndNewValue(oldvalue, newvalue, () => ((CardView)bindable).ChangeCardViewHeightRequest());
    }

    private static void CardViewOutlineColorChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        CompareOldAndNewValue(oldvalue, newvalue, () => ((CardView)bindable).ChangeCardViewOutlineColor());
    }

    private static void CardViewInnerFrameOutlineColorChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        CompareOldAndNewValue(oldvalue, newvalue, () => ((CardView)bindable).ChangeCardViewInnerFrameOutlineColor());
    }

    private static void CardViewOutlineColorThicknessChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        CompareOldAndNewValue(oldvalue, newvalue, () => ((CardView)bindable).ChangeCardViewOutlineColorThickness());
    }

    private static void CardViewInnerFrameOutlineColorThicknessChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        CompareOldAndNewValue(oldvalue, newvalue, () => ((CardView)bindable).ChangeCardViewInnerFrameOutlineColorThickness());
    }

    private static void CardViewHasShadowChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        CompareOldAndNewValue(oldvalue, newvalue, () => ((CardView)bindable).ChangeCardViewOutlineColorHasShadow());
    }

    private static void CardViewSwipeToClearPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        CompareOldAndNewValue(oldvalue, newvalue, () => ((CardView)bindable).ChangeIsSwipeToClearProperty());
    }

    private static void CardViewHorizontalOptionsChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        CompareOldAndNewValue(oldvalue, newvalue, () => ((CardView)bindable).ChangeHorizontalOptionsProperty());
    }

    private void ChangeCardViewContent() => _innerFrame.Content = CardViewContent;

    private void ChangeHorizontalOptionsProperty() => _innerFrame.HorizontalOptions = CardViewHorizontalOptions;

    private void ChangeCardViewHeightRequest()
    {
        _outerFrame.HeightRequest = CardViewHeightRequest;
        _innerFrame.HeightRequest = CardViewHeightRequest;
    }

    private void ChangeCardViewOutlineColor() => _outerFrame.BackgroundColor = CardViewOutlineColor;

    private void ChangeCardViewInnerFrameOutlineColor() => _innerFrame.BackgroundColor = CardViewInnerFrameOutlineColor;

    private void ChangeCardViewOutlineColorThickness() => _outerFrame.Padding = CardViewOutlineColorThickness;

    private void ChangeCardViewInnerFrameOutlineColorThickness() => _innerFrame.Padding = CardViewInnerFrameOutlineColorThickness;

    private void ChangeCardViewOutlineColorHasShadow() => _outerFrame.HasShadow = CardViewHasShadow;

    private void ChangeIsSwipeToClearProperty()
    {
        if (IsSwipeToClearEnabled)
        {
            SetUpPanGesture();
            Content.GestureRecognizers.Add(_panGestureRecognizer);
            return;
        }

        Content.GestureRecognizers.Remove(_panGestureRecognizer);
    }

    private static void CompareOldAndNewValue(object oldvalue, object newvalue, Action changeValueOfChosenProperty)
    {
        if (oldvalue != newvalue)
        {
            changeValueOfChosenProperty();
        }
    }

    private void SetUpPanGesture()
    {
        _panGestureRecognizer.TouchPoints = 1;
        _panGestureRecognizer.PanUpdated += PanGestureRecognizerOnPanUpdated;
    }

    private void PanGestureRecognizerOnPanUpdated(object sender, PanUpdatedEventArgs panUpdatedEventArgs)
    {
        double totalWidthNeededForClearingContent = Content.Width * 4 / 5;

        if (Math.Abs(panUpdatedEventArgs.TotalX) < totalWidthNeededForClearingContent)
        {
            _ = Dispatcher.Dispatch(() =>
            {
                if (Content is not null)
                {
                    Content.GestureRecognizers.Remove(_panGestureRecognizer);
                    Content = null;
                }
            });
        }
    }
}
