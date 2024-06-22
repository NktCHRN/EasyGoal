// material-ui
import useMediaQuery from '@mui/material/useMediaQuery';
import Box from '@mui/material/Box';

// project import
import Profile from './Profile';
import MobileSection from './MobileSection';

// ==============================|| HEADER - CONTENT ||============================== //

export default function HeaderContent() {
  const downLG = useMediaQuery((theme) => theme.breakpoints.down('lg'));

  return (
    <>
      {!downLG && <Box sx={{ width: '100%', ml: { xs: 0, md: 1 } }}></Box>}
      {downLG && <Box sx={{ width: '100%', ml: 1 }} />}
      {!downLG && <Profile />}
      {downLG && <MobileSection />}
    </>
  );
}
