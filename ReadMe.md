# MessageBoxes Documentation

## Overview

This documentation provides guidance on how to use the `MessageBoxes.dll` library in your project. This library includes functionalities for displaying various message boxes, such as informational, confirmation, and error messages.

## Referencing MessageBoxes.dll

To use the `MessageBoxes` library, you need to reference `MessageBoxes.dll` in your project. 

1. **Add Reference**:
   - Right-click on your project in the Solution Explorer.
   - Select **Add** > **Reference...**.
   - In the Reference Manager, browse to the location of `MessageBoxes.dll` and add it.

2. **Include the Namespace**:
   At the top of your code file, include the `MessageBoxes` namespace:

   ```csharp
   using MessageBoxes;
   ```

## Using Message Boxes

### InfoBox

To show an informational message box, use the `InfoBox.Show` method:

```csharp
InfoBox.Show("Title", "Message");
```

- **Parameters**:
  - `Title`: The title of the message box.
  - `Message`: The message content displayed in the box.

### ConfirmBox

To display a confirmation message box that asks the user to confirm an action, use the `ConfirmBox`:

```csharp
var result = ConfirmBox.Show("Title", "Do you want to proceed?");
if (result == ConfirmBoxResult.Yes)
{
    // User clicked Yes
}
else
{
    // User clicked No
}
```

- **Returns**:
  - `ConfirmBoxResult.Yes`: User clicked Yes.
  - `ConfirmBoxResult.No`: User clicked No.

### ErrorBox

To show an error message box, use the `ErrorBox`:

```csharp
try
{
    // Code that may throw an exception
}
catch (Exception ex)
{
    ErrorBox.Show(ex);
}
```

```csharp
ErrorBox.Show("Error Title", "An error occurred. Please try again.");
```

- **Parameters**:
  - `Error Title`: The title of the error message box.
  - `Error Message`: The message explaining the error.

## Examples from MessageBoxSender

You can see examples of how to call these message boxes in the `message.bat` file of the `MessageBoxSender` application. Here are some sample calls:

```bat
:: Example of InfoBox
MessageBoxSender InfoBox "Application Update" "An update is available."

:: Example of ConfirmBox
MessageBoxSender ConfirmBox "Confirmation" "Do you want to save changes?"

:: Example of ErrorBox
MessageBoxSender ErrorBox "Critical Error" "An unexpected error has occurred."
```

## Conclusion

This document outlines how to use the `MessageBoxes.dll` in your project effectively. You can now display informative, confirmatory, and error messages using the provided methods. For any further questions, refer to the documentation of the `MessageBoxes` library or seek additional resources.