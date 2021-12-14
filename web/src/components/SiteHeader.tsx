import { createUseStyles } from "react-jss";
import { SiteTheme, SiteThemeColors, useSiteTheme } from "./SiteTheme";
import { HeaderOne } from "./Typography";

type StyleNames = "root";
type SiteHeaderProps = {};

const useStyles = createUseStyles<StyleNames, SiteHeaderProps, SiteTheme>({
  root: {
    alignItems: "center",
    backgroundColor: ({ theme }) => theme.red,
    display: "flex",
    height: "75px",
    justifyContent: "center",
    width: "100%",
  },
});

export default function SiteHeader() {
  const theme = useSiteTheme();
  const styles = useStyles({ theme });

  return (
    <div className={styles.root}>
      <HeaderOne textColor={SiteThemeColors.white}>The Address Book</HeaderOne>
    </div>
  );
}
