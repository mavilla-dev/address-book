import { createUseStyles } from "react-jss";
import { SiteTheme } from "./SiteTheme";

type Props = {
  children: React.ReactNode;
};

type Styles = "gutter";

const useStyles = createUseStyles<Styles, Props, SiteTheme>({
  gutter: {
    maxWidth: "1080px",
    margin: "0 auto",
    padding: "0 20px",
  },
});

export default function Gutter(props: Props) {
  const styles = useStyles();

  return <div className={styles.gutter}>{props.children}</div>;
}
