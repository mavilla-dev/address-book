import { createUseStyles } from "react-jss";
import {
  getColorCodeFromEnum,
  getFontSizeFromLevel,
  SiteFontLevels,
  SiteTheme,
  SiteThemeColors,
  useSiteTheme,
} from "./SiteTheme";

type Props = {
  children: React.ReactNode;
  textColor?: SiteThemeColors;
};

type BaseProps = {
  fontLevel: SiteFontLevels;
} & Props;

export function HeaderOne(props: Props) {
  return <AbstractTypography fontLevel={SiteFontLevels.h1} {...props} />;
}

export function HeaderTwo(props: Props) {
  return <AbstractTypography fontLevel={SiteFontLevels.h2} {...props} />;
}

export function HeaderThree(props: Props) {
  return <AbstractTypography fontLevel={SiteFontLevels.h3} {...props} />;
}

export function HeaderFour(props: Props) {
  return <AbstractTypography fontLevel={SiteFontLevels.h4} {...props} />;
}

export function Body(props: Props) {
  return <AbstractTypography fontLevel={SiteFontLevels.body} {...props} />;
}

type TypographyClasses = "typeStyles";

const useStyles = createUseStyles<TypographyClasses, BaseProps, SiteTheme>({
  typeStyles: {
    color: ({ textColor }) =>
      getColorCodeFromEnum(textColor ?? SiteThemeColors.black),
    fontSize: ({ fontLevel }) => getFontSizeFromLevel(fontLevel),
  },
});

function AbstractTypography(props: BaseProps) {
  const theme = useSiteTheme();
  const styles = useStyles({ ...props, theme });

  return <div className={styles.typeStyles}>{props.children}</div>;
}
