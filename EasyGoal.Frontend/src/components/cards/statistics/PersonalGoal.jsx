import PropTypes from 'prop-types';

// material-ui
import Chip from '@mui/material/Chip';
import Grid from '@mui/material/Grid';
import Stack from '@mui/material/Stack';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import CircularProgress from '@mui/material/CircularProgress'
import { Tooltip } from '@mui/material';

// project import
import MainCard from 'components/MainCard';

// assets
import RiseOutlined from '@ant-design/icons/RiseOutlined';
import FallOutlined from '@ant-design/icons/FallOutlined';

const iconSX = { fontSize: '0.75rem', color: 'inherit', marginLeft: 0, marginRight: 0 };

export default function PersonalGoalCard({ name, description, doneTasks, totalTasks, doneTasksPercentage, deadline }) {
  const series = [0];
  const options = {
    chart: {
      type: 'radialBar'
    },
    plotOptions: {
      radialBar: {
        hollow: {
          size: '70%'
        }
      }
    },
    labels: ['Progress']
  }

  return (
    <MainCard contentSX={{ p: 2.25 }}>
      <Stack spacing={0.5}>
        <Tooltip title={name} arrow>
        <Typography variant="h6" color="text.secondary" sx={{
        display: '-webkit-box',
        overflow: 'hidden',
        textOverflow: "ellipsis",
        WebkitBoxOrient: 'vertical',
        WebkitLineClamp: 1,
    }}>
          {name}
        </Typography>
        </Tooltip>
        <Grid container alignItems="center" justifyContent="space-between">
            <Grid item>
              <Stack spacing={0.5}>
              <Typography variant="h4" color="inherit">
              {doneTasks} / {totalTasks} <Typography display="inline" color="text.secondary" variant="h6">({doneTasksPercentage.toFixed(2)}%)</Typography>
            </Typography>
              <Chip
                variant="combined"
                color='warning'
                label={`Deadline: ${deadline}`}
                sx={{ mb: 0.5 }}
                size="small"
              />
              </Stack>
            </Grid>
            <Grid item>
            <Tooltip title={`${doneTasksPercentage}%`} arrow>
            <CircularProgress variant="determinate" value={doneTasksPercentage} />
            </Tooltip>
            <Box width="75px"></Box>
            </Grid>
        </Grid>
      </Stack>
      <Box mt="15px">
        <Typography     sx={{
        display: '-webkit-box',
        overflow: 'hidden',
        WebkitBoxOrient: 'vertical',
        WebkitLineClamp: 5,
    }} variant="caption" color="text.secondary">
          {description}
        </Typography>
      </Box>
    </MainCard>
  );
}

PersonalGoalCard.propTypes = {
  color: PropTypes.string,
  title: PropTypes.string,
  count: PropTypes.string,
  percentage: PropTypes.number,
  isLoss: PropTypes.bool,
  extra: PropTypes.string
};
