import { render, screen, fireEvent } from '@testing-library/react';
import { CurrencyTransfer } from './CurrencyTransfer';
import { vi } from 'vitest';

describe('CurrencyTransfer - пересчёт результата', () => {
  const mockOnAmountChange = vi.fn();
  const mockOnFromCurrencyChange = vi.fn();
  const mockOnToCurrencyChange = vi.fn();
  const mockOnSwap = vi.fn();

  const from = {
    value: 1,
    code: 'PLN',
    name: 'Polish zloty',
    description: '',
    symbol: 'zł'
  };

  const to = {
    value: 36.05,
    code: 'JPY',
    name: 'Japanese yen',
    description: '',
    symbol: '¥'
  };

  it('обновляет from.value и to.value в Header и TableTranslation', () => {
    const { rerender } = render(
      <CurrencyTransfer
        from={from}
        to={to}
        date={new Date()}
        onFromCurrencyChange={mockOnFromCurrencyChange}
        onToCurrencyChange={mockOnToCurrencyChange}
        onAmountChange={mockOnAmountChange}
        onSwap={mockOnSwap}
      />
    );
    const fromInput = screen.getByTestId('from-currency-input');

    fireEvent.change(fromInput, { target: { value: '100' } });
    const currentFrom = { ...from, value: 100 };
    rerender(
      <CurrencyTransfer
        from={currentFrom}
        to={to}
        date={new Date()}
        onFromCurrencyChange={mockOnFromCurrencyChange}
        onToCurrencyChange={mockOnToCurrencyChange}
        onAmountChange={mockOnAmountChange}
        onSwap={mockOnSwap}
      />
    );

    expect(fromInput).toHaveValue('100');
    expect(screen.getByTestId('to-currency-value')).toHaveTextContent('3605');
    expect(screen.getByText(/100 Polish zloty is/)).toBeInTheDocument();
    expect(screen.getByText(/3605 Japanese yen/)).toBeInTheDocument();
  });
});
