// material-ui
import { useTheme } from '@mui/material/styles';

import logo from 'assets/images/logo.png';

const Logo = () => {
  const theme = useTheme();

  return (
       <img src={logo} alt="EasyGoal" width="150" />
  );
};

export default Logo;
