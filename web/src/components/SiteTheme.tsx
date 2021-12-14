import { Classes, Styles } from "jss";
import { createUseStyles, useTheme } from "react-jss";

export type SiteTheme = {
  black: string;
  white: string;
  red: string;
};

export const siteColorCodes: SiteTheme = {
  black: "#000000",
  white: "#ffffff",
  red: "#f4311e",
};

export enum SiteThemeColors {
  black,
  white,
  red,
}

export enum SiteFontLevels {
  h1,
  h2,
  h3,
  h4,
  body,
}

export function useSiteTheme() {
  return useTheme<SiteTheme>();
}

export function getColorCodeFromEnum(color: SiteThemeColors): string {
  switch (color) {
    case SiteThemeColors.black:
      return siteColorCodes.black;

    case SiteThemeColors.red:
      return siteColorCodes.red;

    case SiteThemeColors.white:
      return siteColorCodes.white;
  }
}

export function getFontSizeFromLevel(level: SiteFontLevels): string {
  switch (level) {
    case SiteFontLevels.h1:
      return "40px";

    case SiteFontLevels.h2:
      return "30px";

    case SiteFontLevels.h3:
      return "26px";

    case SiteFontLevels.h4:
      return "22px";

    case SiteFontLevels.body:
      return "18px";
  }
}
