<?php
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Get the form fields
    $name = $_POST['name'];
    $email = $_POST['email'];
    $message = $_POST['message'];

    // Email subject
    $subject = 'New message from your website';

    // Email body
    $body = "Name: $name\nEmail: $email\n\n$message";

    // Email headers
    $headers = "From: $name <$email>";

    // Your email address
    $to = 'tnmguimaraes@gmail.com';

    // Send email
    if (mail($to, $subject, $body, $headers)) {
        echo 'Message sent successfully!';
    } else {
        echo 'Sorry, an error occurred. Please try again later.';
    }
} else {
    // If it's not a POST request, redirect to the homepage or display an error message
    echo 'Invalid request!';
}
?>
