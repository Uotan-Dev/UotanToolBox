@ECHO OFF
mode con cols=66 lines=35
TITLE About Language

:START
ECHO.
ECHO.After V2.0.6, you could easily translate viQOO to your own language. Now viQOO could be shown in any language theoretically.
ECHO.
ECHO.This is my first attempt, i could not guarantee its' availability.
ECHO.
ECHO.Translate may need some knowledge of bat.
ECHO.
ECHO.
ECHO.How to translate viQOO:
ECHO.
ECHO.1.Open bin\language, create a new folder named [the English name of your language].
ECHO.
ECHO.2.Open bin\language\chinese-simplified, copy all bat in it to your folder.
ECHO.
ECHO.3.Enter your folder and translate bat. Do not change filename.
ECHO.
ECHO.4.Copy translated bat to bin\language\selected and run viQOO to see changes.
ECHO.
ECHO.
ECHO.How to submit your translation to developer:
ECHO.
ECHO.If your bat could work well, you could copy your folder to \log and use feedback. The feedback script will zip log folder automatically and send email to developer.
ECHO.
ECHO.
ECHO.
ECHO.
ECHO.
ECHO.
pause>nul
goto START